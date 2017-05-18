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
        PlayerPrefs.SetString("Room","B");//利用substring直接抓去了哪裡
        GameObject.Find("ME").transform.position = new Vector3(-4f,0f,0f);
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
