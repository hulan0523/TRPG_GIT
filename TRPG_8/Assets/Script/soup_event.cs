using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soup_event : MonoBehaviour {

    Text MsgText;


    public void point_click()
    {
        GameObject.Find("ME").GetComponent<playerMove>().enabled = false;
        GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = true;
        MsgText = GameObject.Find("MsgText").GetComponent<Text>();
        MsgText.text = "這個湯有毒\n";
        MsgText.text += "進行靈感判定";
        GameObject.Find("dice").GetComponent<dice>().enabled = true;
        dice dice = new dice();
        MsgText.text += "  擲到" + dice.ThrowNum();
    }
}
