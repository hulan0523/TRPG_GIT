using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class survey : MonoBehaviour {
    Text MsgText;

    public void Survey_OnClick()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        if(focusingObject == "Soup")
        {
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "這似乎是一個裝著深紅色湯的碗，散發著熱騰騰的蒸氣，湯呈現稠稠的狀態\n" +
                "嗚! 而且一股與鐵鏽味相似的惡臭襲上鼻腔\n";
            dice dice = new dice();
            MsgText.text += "喪失san值:" + dice.ThrowNum(); ;
        }
        else if(focusingObject == "Candle")
        {
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "放在燭台上的蠟燭以微弱的光照亮著房間...";
        }
        else if(focusingObject == "Book")
        {
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "名為<關於湯之夢>的漆黑書籍。\n"+
                "書本潮濕而帶有黏性，碰到時發現上面沾附著帶有甜甜香氣的黑色液體。\n"+
                "<關於湯之夢>書中內容如下 正中間的房間--不好好把湯喝完就無法離開，在紙條背後寫著湯的真面目 北邊房間---放著很多調味料與餐具，有放點預備的湯在鍋子中。 東邊房間---乖孩子在等著你，她手上有好東西喔。 西邊房間---書很重要所以不能拿出去，不過蠟燭就沒關係。 南邊房間---神明在此沉眠，有著關於毒的資料，守衛不吃活的東西不會消失。 最重要的事情---請抱著死的覺悟喝下去";
        }
    }
    public void Pick_OnClick()    
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        Instantiate (GameObject.Find(focusingObject), Vector3(2, -1, 0), Quaternion.identity);
        CmdPickObject();
    }
    public void Open_OnClick()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        if(focusingObject == "BtoA" )
        {
            PlayerPrefs.SetString("Room","A");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "CtoA" )
        {
            PlayerPrefs.SetString("Room","A");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "DtoA" )
        {
            PlayerPrefs.SetString("Room","A");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "EtoA" )
        {
            PlayerPrefs.SetString("Room","A");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "AtoB" )//去左邊房間
        {
            PlayerPrefs.SetString("Room","B");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "AtoC" //去上面房間
        {
            PlayerPrefs.SetString("Room","C");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "AtoD") //去右邊房間
        {
            PlayerPrefs.SetString("Room","D");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
        else if(focusingObject == "AtoE") //去下面房間
        {
            PlayerPrefs.SetString("Room","E");
            GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
        }
    } 

    [Command]
    void CmdPickObject()
    {
        RpcPickObject();
    }
    [ClientRpc]
    void RpcPickObject()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        Destory(GameObject.Find(focusingObject));
    }
}
