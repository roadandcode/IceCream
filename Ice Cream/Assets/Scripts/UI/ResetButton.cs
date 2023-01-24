using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetButton : Button
{
    public Action onReset;

    public override void OnPointerClick(PointerEventData eventData)
    {
        onReset.Invoke();
    }
}
