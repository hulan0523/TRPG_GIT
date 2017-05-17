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
                next = 0;
            }

        }
    }
}
