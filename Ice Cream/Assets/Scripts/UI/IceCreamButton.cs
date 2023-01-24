using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IceCreamButton : Button
{
    public CreamType CreamType;

    public Action OnButtonHolding;
    public Action OnButtonReleased;

    public bool IsActive = true;
    private bool _isHolding;
 
    private void Update()
    {
        if (!IsActive)
            return;

        if (_isHolding)
        {
            OnButtonHolding.Invoke();
            Debug.Log("Pressing Button");
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        _isHolding = true;
       
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _isHolding = false;
        OnButtonReleased.SafeInvoke();
    }
}



