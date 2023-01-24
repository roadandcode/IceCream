using BezierSolution;
using DG.Tweening;
using UnityEngine;

public class Machine : MonoBehaviour
{
    private IceCreamBase currentIceCream;
    private ResetButton resetButton;
    private MachineMovement creamMachineMovementController;

    private bool levelCompleted = false;
    private int currentLayer;

    private void Awake()
    {
        currentIceCream = FindObjectOfType<IceCreamBase>();
        creamMachineMovementController = FindObjectOfType<MachineMovement>();
        resetButton = FindObjectOfType<ResetButton>();

        Initialize();
    }

    public void Initialize()
    {
        currentLayer = 0;
        creamMachineMovementController.OnPathCompleted += UpdateLayer;
        creamMachineMovementController.OnStartIceCream += GeneratedCream;
        resetButton.onReset += ResetGame;

        UpdateLayer();
    }

    private void GeneratedCream(CreamType creamType, BezierSpline bezier, Transform iceCreamFilter)
    {
        if (levelCompleted)
            return;
        
            var iceCreamDrop = IceCreamDropPoolManager.instance.GetCreamAvailableCream(creamType);
            iceCreamDrop.transform.eulerAngles = new Vector3(0, 0, 0);
            iceCreamDrop.transform.position = iceCreamFilter.position;
            iceCreamDrop.transform.DOMove(bezier.GetPoint(creamMachineMovementController.NormalizedT), 2f);
            var look = Quaternion.LookRotation(bezier.GetTangent(creamMachineMovementController.NormalizedT));
            var h = look.eulerAngles;
            var finalLook = Quaternion.Euler(look.x, h.y + 90, 90f);


            iceCreamDrop.transform.DORotateQuaternion(finalLook, 2f);

            if (creamMachineMovementController.NormalizedT >= 1)
            {
                UpdateLayer();
            }
        
      

    }

    private void UpdateLayer()
    {
        if (currentIceCream == null)
            return;


        CheckLevelStatus();
        var creamSpline = currentIceCream.CreamSplineManager.GetCreamByLayer(currentLayer++);

        if (creamSpline != null)
        {
            creamMachineMovementController.NormalizedT = 0;
            creamMachineMovementController.SetBezierSpline(creamSpline.BezierSpline);
        }

    }

    private void CheckLevelStatus()
    {
        if (currentLayer > 8)
        {
            currentLayer = 0;
            Debug.Log("Level Complete");
            levelCompleted = true;
        }
    }

    void ResetGame()
    {
        if (!levelCompleted)
            return;

        IceCreamDropPoolManager.instance.DeactivateWholePool();
        levelCompleted = false;
    }
}

