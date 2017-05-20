using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soup_event : MonoBehaviour {

    Text MsgText;
    Canvas OptionCanvas;
    
    public void point_click()
    {
        gameObject.GetComponent<soup_event>().enabled = false;
        GameObject.Find("ME").GetComponent<playerMove>().enabled = false;
        GameObject.Find("Option").GetComponent<Canvas>().enabled = true;
        PlayerPrefs.SetString("FocusAt",gameObject.name);
        if(gameObject.tag == "Door")
        {
            GameObject.Find("Btn2_text").GetComponent<Text>().text = "打開";
        }
        if(gameObject.tag == "Pick")
        {
            GameObject.Find("Btn2_text").GetComponent<Text>().text = "撿起";
        }
    }
}
