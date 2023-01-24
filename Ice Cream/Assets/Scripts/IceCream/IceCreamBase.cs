using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IceCreamBase : MonoBehaviour
{
    public CreamSplineManager CreamSplineManager;

    private void Awake()
    {
        var creamSplines = GetComponentsInChildren<IceCreamSpline>().ToList();
        CreamSplineManager = new CreamSplineManager(creamSplines);
    }
 
}
