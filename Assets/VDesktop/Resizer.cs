using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resizer : MonoBehaviour, IDragHandler
{
    public RectTransform window;
    public Vector2 minSize = new Vector2(100, 100);
    public bool left, right, top, bottom;
    Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData e)
    {
        Vector2 delta = e.delta / canvas.scaleFactor;
        Vector2 size = window.sizeDelta;
        Vector2 pos = window.anchoredPosition;

        if (right) size.x += delta.x;
        if (left) size.x -= delta.x;
        if (top) size.y += delta.y;
        if (bottom) size.y -= delta.y;

        float newX = Mathf.Max(size.x, minSize.x);
        float newY = Mathf.Max(size.y, minSize.y);

        if (left) pos.x += window.sizeDelta.x - newX;
        if (top) pos.y += newY - window.sizeDelta.y;

        window.sizeDelta = new Vector2(newX, newY);
        window.anchoredPosition = pos;


    }

}
