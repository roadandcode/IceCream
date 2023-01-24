using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BezierSolution;

public class IceCreamSpline : MonoBehaviour
{
    public CreamInfo CreamInfo;
    public BezierSpline BezierSpline => GetComponent<BezierSpline>();
}


public enum CreamType
{
    NONE,
    VANILLA,
    STRAWBERRY,
    CHOCOLATE,
    
}

[Serializable]
public class CreamInfo
{
    public int Layer;
    public CreamType CreamType;

    public CreamInfo(int layer, CreamType type)
    {
        Layer = layer;
        CreamType = type;
    }
 
}

