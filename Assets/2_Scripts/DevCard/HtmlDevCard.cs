using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HtmlDevCard : MonoBehaviour, IDevCard
{
    [field: SerializeField] public string cardName {get; set;}
    [field: SerializeField] public string cardType {get; set;}
    [field: SerializeField] bool needClosedTag;

    List<HtmlDevCard> children = new List<HtmlDevCard>();   // 자식 카드들
    HtmlDevCard topCard;    // 자신의 위에 있는 카드
    HtmlDevCard bottomCard; // 자기 아래에 있는 카드

    public void MakeCode()
    {
        Debug.Log("코드 만들기");
    }

    

}
