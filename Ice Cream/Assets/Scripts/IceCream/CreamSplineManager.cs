using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreamSplineManager 
{
    private List<IceCreamSpline> _iceCreamSplines;

    public CreamSplineManager(List<IceCreamSpline> splines)
    {
        _iceCreamSplines = splines;
        SetIceCreamLayer();
    }

    public IceCreamSpline GetCreamByLayer(int layer)
    {
        return _iceCreamSplines?.FirstOrDefault(x => x.CreamInfo.Layer == layer);
    }

    public void UpdateCreamInfos(List<CreamInfo> creamInfos)
    {
        foreach (var info in creamInfos)
        {
            var creamSpline = _iceCreamSplines?.FirstOrDefault(x => x.CreamInfo.Layer == info.Layer);
            if (creamSpline != null)
                creamSpline.CreamInfo.CreamType = info.CreamType;
        }
    }

    void SetIceCreamLayer()
    {
        for (int i = 0; i < _iceCreamSplines.Count; i++)
        {
            _iceCreamSplines[i].CreamInfo.Layer = i;
        }
    }

    public List<CreamInfo> GetIceCreamInfos()
    {
        List<CreamInfo> creamInfos = new List<CreamInfo>();
        foreach (var creamSpline in _iceCreamSplines)
        {
            creamInfos.Add(creamSpline.CreamInfo);
        }

        return creamInfos;
    }
}
