using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerState : MonoBehaviour
{
    int my_san = 100;
    Text MsgText;
    int next = 0;
    public int return_san()
    {
        return my_san;
    }
    private void Update()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        if (Input.GetKeyDown("space"))
        {
            if (focusingObject == "Soup" && next == 0)
            {
                MsgText = GameObject.Find("MsgText").GetComponent<Text>();
                MsgText.text = "這似乎是一個裝著深紅色湯的碗，散發著熱騰騰的蒸氣，湯呈現稠稠的狀態\n" +
                    "嗚! 而且一股與鐵鏽味相似的惡臭襲上鼻腔\n";
                next++;
                dice dice = new dice();
                MsgText.text += "喪失san值:" + dice.ThrowNum(); ;
            }
            else if (focusingObject == "Soup" && next == 1)
            {
                GameObject.Find("dice").GetComponent<Animator>().SetInteger("diceNum", 0);
                GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = false;
                GameObject.Find("ME").GetComponent<playerMove>().enabled = true;
                GameObject.Find("Option").GetComponent<Canvas>().enabled = false;
                GameObject.Find(focusingObject).GetComponent<soup_event>().enabled = true;
                next = 0;
            }
            else if (focusingObject == "Book" && next == 0)
            {
                GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
                MsgText = GameObject.Find("MsgText").GetComponent<Text>();
                MsgText.text = "名為<關於湯之夢>的漆黑書籍。\n" +
                    "書本潮濕而帶有黏性，碰到時發現上面沾附著帶有甜甜香氣的黑色液體。\n" +
                    
                next++;
            }
            else if (focusingObject == "Book" && next == 1)
            {
                MsgText.text += "<關於湯之夢>書中內容如下 正中間的房間--不好好把湯喝完就無法離開，在紙條背後寫著湯的真面目\n" +
                    "北邊房間---放著很多調味料與餐具，有放點預備的湯在鍋子中。\n " +
                    "東邊房間---乖孩子在等著你，她手上有好東西喔。\n " +
                    "西邊房間---書很重要所以不能拿出去，不過蠟燭就沒關係。\n " +
                    "南邊房間---神明在此沉眠，有著關於毒的資料，守衛不吃活的東西不會消失。\n " +
                    "最重要的事情---請抱著死的覺悟喝下去";
                next++;
            }
            else if (focusingObject == "Book" && next == 2)
            {
                MsgText.text += "西邊房間---書很重要所以不能拿出去，不過蠟燭就沒關係。\n " +
                    "南邊房間---神明在此沉眠，有著關於毒的資料，守衛不吃活的東西不會消失。\n " +
                    "最重要的事情---請抱著死的覺悟喝下去";
                next=100;
            }
            else if (next == 100|| focusingObject == "Paper")
            {
                GameObject.Find("dice").GetComponent<Animator>().SetInteger("diceNum", 0);
                GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = false;
                GameObject.Find("ME").GetComponent<playerMove>().enabled = true;
                GameObject.Find("Option").GetComponent<Canvas>().enabled = false;
                GameObject.Find(focusingObject).GetComponent<soup_event>().enabled = true;
                next = 0;
            }

        }
    }
}
