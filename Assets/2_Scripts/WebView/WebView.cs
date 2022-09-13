using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class WebView : MonoBehaviour
{
    string URL = "/index.htm";
    //string code = "<!doctype html><html><head><title>example 1-2</title></head><body><H2>example 1-2</H2><HR>example 1-2</body></html>";
    public FileMaker fileMaker;
    private WebViewObject webViewObject;
    [SerializeField] CodeReader codeReader;


    // UI관련 변수
    public Text saveTxt;
    public Text logTxt;

    void Awake()
    {
        fileMaker.gameObject.GetComponent<FileMaker>();  
        saveTxt.gameObject.GetComponent<Text>();  
        logTxt.gameObject.GetComponent<Text>();
        codeReader = codeReader.gameObject.GetComponent<CodeReader>();    
    }
    void Start()
    {
        //fileMaker.MakeFile(code, "/index");
        //StartWebView();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            if (Input.GetKey(KeyCode.Escape))
            {
                // 뒤 로 가 기, esc 버 튼 
                Destroy(webViewObject);
                return;
            }
        }
    }

    public void StartWebView()
    {
        string strUrl = Application.persistentDataPath + URL;

        logTxt.text += "\nStartWebview\n" + strUrl;

        try
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init((msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
                logTxt.text += string.Format("CallFromJS[{0}]", msg);
            });

            webViewObject.LoadURL(strUrl);
            webViewObject.SetVisibility(true);
            webViewObject.SetMargins(200, 50, 200, 50); // 좌, 상, 우, 하
        }
        catch( System.Exception e)
        {
            print($"WebView Error : {e}");
        }
    }

    public void OnClickedSaveButton()
    {
        string code = codeReader.ReadDevCard();
        fileMaker.MakeFile(code, "/index");
        saveTxt.text += "\nsaveHtml";
    }

    public void OnClickedStartWebview()
    {
        StartWebView();
    }
}
