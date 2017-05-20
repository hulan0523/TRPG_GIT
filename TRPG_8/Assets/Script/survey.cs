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
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "想回去的話 便在一小時之內 喝下有毒的湯。\n" +
                "在喝完之前 你都無法離開。\n"+
                "一小時內 沒有喝完的話 祂便會來迎接你~\n";
        }
        else if (focusingObject == "Candle")
        {
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "放在燭台上的蠟燭以微弱的光照亮著房間...";
        }
        else if (focusingObject == "Book")
        {
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
            MsgText = GameObject.Find("MsgText").GetComponent<Text>();
            MsgText.text = "名為<關於湯之夢>的漆黑書籍。\n" +
                "書本潮濕而帶有黏性，碰到時發現上面沾附著帶有甜甜香氣的黑色液體。\n";
        }
    }
    public void Button2_OnClick()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        GameObject.Find(focusingObject).GetComponent<soup_event>().enabled = true;
        GameObject.Find("ME").GetComponent<playerMove>().enabled = true;
        GameObject.Find("Option").GetComponent<Canvas>().enabled = false;
        if (GameObject.Find("Btn2_text").GetComponent<Text>().text == "打開")
        {
            if (focusingObject == "BtoA")
            {
                PlayerPrefs.SetString("PlayerAtRoom", "A");
                GameObject.Find("ME").transform.position = new Vector3(-1.6f, 0f, 0f);
            }
            else if (focusingObject == "CtoA")
            {
                PlayerPrefs.SetString("PlayerAtRoom", "A");
                GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
            }
            else if (focusingObject == "DtoA")
            {
                PlayerPrefs.SetString("PlayerAtRoom", "A");
                GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
            }
            else if (focusingObject == "EtoA")
            {
                PlayerPrefs.SetString("PlayerAtRoom", "A");
                GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
            }
            else if (focusingObject == "AtoB")//去左邊房間
            {
                PlayerPrefs.SetString("PlayerAtRoom", "B");
                GameObject.Find("ME").transform.position = new Vector3(-3.1f, 0f, 0f);
            }
            else if (focusingObject == "AtoC") //去上面房間
            {
                PlayerPrefs.SetString("PlayerAtRoom", "C");
                GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
            }
            else if (focusingObject == "AtoD") //去右邊房間
            {
                PlayerPrefs.SetString("PlayerAtRoom", "D");
                GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
            }
            else if (focusingObject == "AtoE") //去下面房間
            {
                PlayerPrefs.SetString("PlayerAtRoom", "E");
                GameObject.Find("ME").transform.position = new Vector3(-3.1f, 0f, 0f);
            }
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("ME").GetComponent<playerMove>().enabled = true;
        }
        else if(GameObject.Find("Btn2_text").GetComponent<Text>().text == "撿起")
        {
            Instantiate(GameObject.Find(focusingObject), new Vector3(2, -1, 0), Quaternion.identity);
            //CmdPickObject();
        }
    }
}
