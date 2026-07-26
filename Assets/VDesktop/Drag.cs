using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler
{
    public RectTransform window;
    Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData e)
    {
        window.anchoredPosition += e.delta / canvas.scaleFactor;
    }


}
