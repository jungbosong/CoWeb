using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevCardMaker : MonoBehaviour
{
    // 클릭했을 때 드래그앤드롭 가능한 obj만들고
    [SerializeField] GameObject cardPrefab;
    GameObject devCard;
    [SerializeField] GameObject devArea;

    public void OnClickedHandCard()
    {
        devCard = (GameObject) Instantiate(cardPrefab);
        devCard.transform.SetParent(devArea.transform);
        devCard.transform.localScale = new Vector3(1f, 1f, 1f);
        devCard.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

}
