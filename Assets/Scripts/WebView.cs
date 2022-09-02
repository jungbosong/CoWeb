using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class WebView : MonoBehaviour
{
    string URL = "/index.htm";
    string code = "<!doctype html><html><head><title>example 1-2</title></head><body><H2>example 1-2</H2><HR>example 1-2</body></html>";
    public FileMaker fileMaker;
    private WebViewObject webViewObject;

    void Awake()
    {
        fileMaker.gameObject.GetComponent<FileMaker>();    
    }
    void Start()
    {
        fileMaker.MakeFile(code, "/index");
        StartWebView();
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

        try
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init((msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
            });

            webViewObject.LoadURL(strUrl);
            webViewObject.SetVisibility(true);
            webViewObject.SetMargins(200, 50, 200, 50);
        }
        catch( System.Exception e)
        {
            print($"WebView Error : {e}");
        }
    }
}
