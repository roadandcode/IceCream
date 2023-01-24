using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Helpers 
{
    public static void SafeInvoke(this Action source)
    {
        if (source != null) source.Invoke();
    }

    public static void SafeInvoke<T>(this Action<T> source, T value)
    {
        if (source != null) source.Invoke(value);
    }

    public static void SafeInvoke<T1, T2>(this Action<T1, T2> source, T1 firstValue, T2 secondValue)
    {
        if (source != null) source.Invoke(firstValue, secondValue);
    }

    public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> source, T1 firstValue, T2 secondValue, T3 thirdValue)
    {
        if (source != null) source.Invoke(firstValue, secondValue, thirdValue);
    }

    public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
    {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }

    public static void ChangePositionY(this Transform thisPosition, float yPosition)
    {
        var tempPos = thisPosition.position;
        tempPos.y = yPosition;

        thisPosition.position = tempPos;
    }
}

public static class GameConfig
{
    public static float SMOOTHNESS = 0f;
    public static float MACHINE_SPEED = 2f;
}
