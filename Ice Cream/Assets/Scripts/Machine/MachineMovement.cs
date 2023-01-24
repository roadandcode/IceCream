using BezierSolution;
using System;
using UnityEngine;


public class MachineMovement : BezierWalkerWithSpeed
{
    [SerializeField] private Transform iceCreamSpawnPoint;

    public Action<CreamType, BezierSpline, Transform> OnStartIceCream;

    private PlayerInputController playerInputController;

    private Vector3 firstPos;
  
    private float spawnWait;
    private float yPosition;
    private bool isActive;


    private void Awake()
    {
        playerInputController = FindObjectOfType<PlayerInputController>();
        playerInputController.SubscribeHoldingEvent(CreamType.CHOCOLATE, () => GenerateCream(CreamType.CHOCOLATE));
        playerInputController.SubscribeHoldingEvent(CreamType.VANILLA, () => GenerateCream(CreamType.VANILLA));
        playerInputController.SubscribeHoldingEvent(CreamType.STRAWBERRY, () => GenerateCream(CreamType.STRAWBERRY));
        playerInputController.SubscribeHoldingEvent(MoveAroundCurve);
        playerInputController.SubscribeReleasingEvent(Stop);

        Initialize();

    }

    public void Initialize()
    {
        firstPos = transform.position;
        yPosition = transform.position.y;
        spawnWait = 0;
        lookAt = LookAtMode.None;
        speed = 2f;
    }

    public void SetBezierSpline(BezierSpline bezierSpline)
    {
        spline = bezierSpline;
    }

    private void MoveAroundCurve()
    {
        isActive = true;
    }

    private void Stop()
    {
        isActive = false;
    }

    protected override void Update()
    {
     
        if (!isActive || spline == null)
            return;

        base.Update();
        UpdateHeightPosition();
        
    }

    private void UpdateHeightPosition()
    {
        spawnWait += Time.deltaTime;
        Helpers.ChangePositionY(transform, yPosition);
    }

    private void GenerateCream(CreamType creamType)
    {
        OnStartIceCream.SafeInvoke(creamType, spline, iceCreamSpawnPoint);
    }

}
