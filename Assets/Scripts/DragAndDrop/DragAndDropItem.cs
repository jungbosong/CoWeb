using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropItem : MonoBehaviour
{
    public Vector3 LoadedPos;
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;
    public bool isInArea;
    float devAreaPosY;

    private void Start() 
    {
        LoadedPos = this.transform.position;    
    }

    private void Update() 
    {
        if(isBeingHeld)    
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position = new Vector2 (mousePos.x - startPosX, mousePos.y - startPosY);
        }

    }

    #region 마우스 드래그앤 드롭
    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            //spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp() 
    {
        //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        isBeingHeld = false;

        if(isInArea)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.localPosition.x, devAreaPosY - 1f, 0f);
        }
        else
        {
            this.gameObject.transform.position = LoadedPos;
        }
    }

    #endregion

    /*#region 개발라인이랑 맞는지
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("DevArea"))    
        {
            isInArea = true;
            devAreaPosY = other.transform.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("DevArea"))    
        {
            isInArea = false;
        }
    }

    #endregion*/
}
