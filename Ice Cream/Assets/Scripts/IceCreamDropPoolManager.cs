using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IceCreamDropPoolManager : MonoBehaviour
{
    public static IceCreamDropPoolManager instance;

    private const string CREAM_PATH = "CreamDrop";

    [SerializeField] private Material vanillaMaterial;
    [SerializeField] private Material strawberryMaterial;
    [SerializeField] private Material chocolateMaterial;

    [SerializeField] IceCreamDrop iceCreamDropPrefab;

    private Material currentCreamMaterial;

    private List<IceCreamDrop> iceCreamDrops;
    private IceCreamDrop iceCreamDrop;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        Initialize();
    }


    public void Initialize()
    {
        iceCreamDrops = GetComponentsInChildren<IceCreamDrop>(true)?.ToList() ?? new List<IceCreamDrop>();
        DeactivateWholePool();
       // iceCreamDrop = Resources.Load<IceCreamDrop>(CREAM_PATH);
    }

    public IceCreamDrop GetCreamAvailableCream(CreamType creamType)
    {
        var cream = iceCreamDrops?.FirstOrDefault(x => !x.IsActive);
        if (cream == null)
        {
            cream = Instantiate(iceCreamDropPrefab, transform);
            cream.CreamType = creamType;
            iceCreamDrops?.Add(cream);
        }

        CheckCreamMat(creamType);
        cream.GetComponentInChildren<MeshRenderer>().material = currentCreamMaterial;
        cream.Activate();
        return cream;
    }

    public void DeactivateWholePool()
    {
        if (iceCreamDrops.Count <= 0)
            return;

        foreach (var creamPiece in iceCreamDrops)
        {
            creamPiece.Deactivate();
            creamPiece.CreamType = CreamType.NONE;
        }
    }

    void CheckCreamMat(CreamType type)
    {
        switch (type)
        {
            case CreamType.VANILLA:
                currentCreamMaterial = vanillaMaterial;
                break;
            case CreamType.STRAWBERRY:
                currentCreamMaterial = strawberryMaterial;
                break;
            case CreamType.CHOCOLATE:
                currentCreamMaterial = chocolateMaterial;
                break;
        }
    }
}
