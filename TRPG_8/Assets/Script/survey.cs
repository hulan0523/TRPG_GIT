using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class survey : MonoBehaviour {
    Text MsgText;

    public void Survey_OnClick()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        if(focusingObject == "Soup")
        {
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;

            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "一拿起來，發現下面壓著一張紙，寫著：\n" +
                "~熱騰騰的 人血湯 請在涼掉之前 盡早享用~";
        }
        else if (focusingObject == "Paper")
        {
            PlayerPrefs.SetInt("ConversationFinish", 0);
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "想回去的話 便在一小時之內 喝下有毒的湯。\n" +
                "在喝完之前 你都無法離開。\n"+
                "一小時內 沒有喝完的話 祂便會來迎接你~\n";
        }
    }
}
