using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("borderTop", 2.5f);
        PlayerPrefs.SetFloat("borderRight", 4f);
        PlayerPrefs.SetFloat("borderBottom", -2.5f);
        PlayerPrefs.SetFloat("borderLeft", -4f);
    }
	
}
