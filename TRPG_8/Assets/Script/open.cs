using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {


    public void Open_OnClick()
    {
        string focusingObject = PlayerPrefs.GetString("FocusAt");
        if (focusingObject == "BtoA")
        {
            PlayerPrefs.SetString("Room", "A");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "CtoA")
        {
            PlayerPrefs.SetString("Room", "A");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "DtoA")
        {
            PlayerPrefs.SetString("Room", "A");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "EtoA")
        {
            PlayerPrefs.SetString("Room", "A");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "AtoB")//去左邊房間
        {
            PlayerPrefs.SetString("Room", "B");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "AtoC") //去上面房間
        {
            PlayerPrefs.SetString("Room", "C");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "AtoD") //去右邊房間
        {
            PlayerPrefs.SetString("Room", "D");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
        else if (focusingObject == "AtoE") //去下面房間
        {
            PlayerPrefs.SetString("Room", "E");
            GameObject.Find("ME").transform.position = new Vector3(-4f, 0f, 0f);
        }
    }
}
