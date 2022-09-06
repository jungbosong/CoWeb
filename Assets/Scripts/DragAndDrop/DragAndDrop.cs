using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public static Vector2 DefaultPos;
    RectTransform rectTransform;
    Canvas devCanvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        devCanvas = this.transform.parent.transform.parent.GetComponent<Canvas>();
        DefaultPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / devCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }
}
