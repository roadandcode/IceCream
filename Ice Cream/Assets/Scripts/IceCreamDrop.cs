using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamDrop : MonoBehaviour
{
    public bool IsActive;
    public CreamType CreamType;

    public void Activate()
    {
        IsActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }
}
