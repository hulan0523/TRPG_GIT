using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("PlayerAtRoom","A");
        PlayerPrefs.SetFloat("A_borderTop", 2.5f);
        PlayerPrefs.SetFloat("A_borderRight", 4f);
        PlayerPrefs.SetFloat("A_borderBottom", -2.5f);
        PlayerPrefs.SetFloat("A_borderLeft", -4f);

        PlayerPrefs.SetFloat("B_borderTop", 2.5f);
        PlayerPrefs.SetFloat("B_borderRight", -1f);
        PlayerPrefs.SetFloat("B_borderBottom", -2.5f);
        PlayerPrefs.SetFloat("B_borderLeft", -9f);
        

    }
	
}
