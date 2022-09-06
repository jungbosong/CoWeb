using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    //[SerializeField] GameObject cardImagePrefab;
    //GameObject devCard;
    public static Vector2 DefaultPos;
    RectTransform rectTransform;
    Canvas devCanvas;
    //[SerializeField] GameObject devArea;

    private void Awake() 
    {
        //rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        devCanvas = this.transform.parent.transform.parent.GetComponent<Canvas>();
        DefaultPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 이전 이동과 비교해서 얼마나 이동했는지 보여줌
        // 캔버스의 스케일과 맞춰야하므로
        rectTransform.anchoredPosition += eventData.delta / devCanvas.scaleFactor;
        //Vector2 currentPos = eventData.position;
        //this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // this.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }
}
