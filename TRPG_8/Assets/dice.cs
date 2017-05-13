using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dice : MonoBehaviour {
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public int ThrowNum()
    {
        anim = GetComponent<Animator>();
        int r = Random.Range(1, 7);
        if (r == 1)
        {
            anim.SetInteger("diceNum", 1);
            Debug.Log("骰到1");
        }
        else if (r == 2)
        {
            anim.SetInteger("diceNum", 2);
            Debug.Log("骰到2");
        }
        else if (r == 3)
        {
            anim.SetInteger("diceNum", 3);
            Debug.Log("骰到3");
        }
        else if (r == 4)
        {
            anim.SetInteger("diceNum", 4);
            Debug.Log("骰到4");
        }
        else if (r == 5)
        {
            anim.SetInteger("diceNum", 5);
            Debug.Log("骰到5");
        }
        else if (r == 6)
        {
            anim.SetInteger("diceNum", 6);
            Debug.Log("骰到6");
        }
        return r;
    }
}
