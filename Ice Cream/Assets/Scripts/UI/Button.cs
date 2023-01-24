using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{

    private Tween _animTween;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        // to do
       
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        // to do 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_animTween != null)
        {
            _animTween.Kill();
        }
        _animTween = transform.DOScale(0.9f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_animTween != null)
        {
            _animTween.Kill();
        }
        _animTween = transform.DOScale(1f, 0.2f);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        // to do 
    }
}
