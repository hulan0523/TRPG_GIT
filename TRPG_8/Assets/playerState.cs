using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour {
    int my_san = 100;

	public int return_san()
    {
        return my_san;
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            GameObject.Find("dice").GetComponent<Animator>().SetInteger("diceNum", 0);
            GameObject.Find("MsgCanvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("ME").GetComponent<playerMove>().enabled = true;
        }
    }
}
