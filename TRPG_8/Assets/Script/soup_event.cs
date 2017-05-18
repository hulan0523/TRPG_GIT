using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soup_event : MonoBehaviour {

    Text MsgText;

    public void point_click()
    {
        gameObject.GetComponent<eventTrigger>().enabled = false;
        GameObject.Find("ME").GetComponent<playerMove>().enabled = false;
        GameObject.Find("Option").GetComponent<Canvas>().enabled = true;
        PlayerPrefs.SetString("FocusAt",gameObject.name);
    }
}
