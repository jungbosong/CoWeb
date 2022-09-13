using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeReader : MonoBehaviour
{
    // devArea에 있는 자식 오브젝트를 하나씩 읽습니다.
    // 하나씩 읽으면서 string에 각각의 태그 이름을 집어 넣습니다.
    // 만약 content 태그라면 text영역에 있는 글을 집어 넣습니다.
    // 만약 HR 태그라면 닫는 태그가 없으므로 stack영역에 넣지 않습니다.
    // 닫는 태그를 구분지어야하기 때문에 임의의 영역에 각각의 태그에 대한 정보를 넣어둡니다.
    // 닫는 태그를 작성하면 임의의 영역에서 제거해줍니다.
    
    string code = "<!doctype html><html>";
    Stack<string> openTag = new Stack<string>();

    [SerializeField] GameObject devArea;

    public string ReadDevCard()
    {
        string lastOpenTagName = "";
        for(int i = 0; i < devArea.transform.childCount; i++)
        {
            GameObject tagObj = devArea.transform.GetChild(i).gameObject;
            string tagName = tagObj.transform.GetChild(0).GetComponent<Text>().text;
            Debug.Log("tagName");
            Debug.Log(tagName);
            if(tagName == lastOpenTagName)
            {
                if(openTag.Count > 1)
                {
                    openTag.Pop();
                    lastOpenTagName = openTag.Peek();
                }
                string closeTag = "</" + tagName.Split('<')[1];
                code += closeTag;
                Debug.Log("closeTag");
                Debug.Log(closeTag);
                continue;
            }
            switch(tagName)
            {
                case "<content>":
                {
                    code += tagObj.transform.GetChild(1).GetComponent<Text>().text;
                    break;
                }
                case "<HR>":
                {
                    code += tagName;
                    break;
                }
                default:
                {
                    openTag.Push(tagName);
                    lastOpenTagName = tagName;
                    Debug.Log("lastOpenTagName");
                    Debug.Log(lastOpenTagName);
                    code += tagName;
                    break;
                }
            }
        }
        code += "</html>";
        return code;
    }
}
