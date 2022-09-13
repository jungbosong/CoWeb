using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevCardMaker : MonoBehaviour
{
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


