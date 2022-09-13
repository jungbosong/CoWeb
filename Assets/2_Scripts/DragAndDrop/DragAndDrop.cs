using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public static Vector2 DefaultPos;       // 시작위치
    RectTransform rectTransform;
    Canvas devCanvas;   
    //RaycastHit2D raycastResult;
    GraphicRaycaster gr;
    RaycastResult raycastResult;
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        devCanvas = GameObject.FindGameObjectWithTag("DevArea").GetComponent<Canvas>();
        Debug.Log(devCanvas.gameObject.name);
        DefaultPos = this.transform.position;
        //ray2D = new Ray2D(this.gameObject.transform.position, Vector2.zero);
        gr = devCanvas.gameObject.GetComponent<GraphicRaycaster>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / devCanvas.scaleFactor;
        //raycastResult = Physics2D.Raycast(this.transform.position, this.transform.forward);
        //eventData.position = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        /*List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(eventData, results);
        if (results.Count <= 0)
        {
            Debug.Log("results.Count <= 0");
        }
        else
        {
            Debug.Log("results.Count > 0");
            raycastResult = results[2];
        }*/

    }

    public void OnEndDrag(PointerEventData eventData)
    {        
        /*Debug.Log("OnEndDrag");
        Debug.Log(raycastResult.gameObject.name);
        string tag = raycastResult.gameObject.tag;
        if(tag == "TopArea")
        {
            Debug.Log("It's in TopArea");
            Debug.Log(raycastResult.gameObject.name);
            rectTransform.anchoredPosition = raycastResult.gameObject.GetComponent<RectTransform>().anchoredPosition;
        }
        else if(tag == "BottomArea")
        {
            Debug.Log("It's in BottomArea");
            Debug.Log(raycastResult.gameObject.name);
            rectTransform.anchoredPosition = raycastResult.gameObject.GetComponent<RectTransform>().anchoredPosition;
        }*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }
}
