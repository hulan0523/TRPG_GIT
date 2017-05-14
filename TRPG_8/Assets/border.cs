using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("borderTop", 2f);
        PlayerPrefs.SetFloat("borderRight", 3.5f);
        PlayerPrefs.SetFloat("borderBottom", -2f);
        PlayerPrefs.SetFloat("borderLeft", -3.5f);
    }
	
}
