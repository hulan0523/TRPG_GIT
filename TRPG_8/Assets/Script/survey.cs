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
