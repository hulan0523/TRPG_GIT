using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soup_event : MonoBehaviour {

    Text MsgText;
    Canvas OptionCanvas;
    
    public void point_click()
    {
        GameObject.Find("ME").GetComponent<playerMove>().enabled = false;
        GameObject.Find("Option").GetComponent<Canvas>().enabled = true;
        PlayerPrefs.SetString("FocusAt",gameObject.name);
    }
}
