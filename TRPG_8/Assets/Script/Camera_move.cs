using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("PlayerAtRoom","A");
    }
    // Update is called once per frame
    void Update()
    {
        string playerAt = PlayerPrefs.GetString("PlayerAtRoom");
        bool stopX= false;
        bool stopY = false;
        float A_borderTop = PlayerPrefs.GetFloat("A_borderTop");
        float A_borderRight = PlayerPrefs.GetFloat("A_borderRight");
        float A_borderBottom = PlayerPrefs.GetFloat("A_borderBottom");
        float A_borderLeft = PlayerPrefs.GetFloat("A_borderLeft");
        float B_borderTop = PlayerPrefs.GetFloat("B_borderTop");
        float B_borderRight = PlayerPrefs.GetFloat("B_borderRight");
        float B_borderBottom = PlayerPrefs.GetFloat("B_borderBottom");
        float B_borderLeft = PlayerPrefs.GetFloat("B_borderLeft");
        try
        {
            if (playerAt == "A" && GameObject.Find("ME").transform.position.x + 3.5f > A_borderRight)//不能往右
            {
                gameObject.transform.position = new Vector3(A_borderRight - 3.5f, gameObject.transform.position.y, -10f);
                stopX = true;
            }
            if (playerAt == "A" && GameObject.Find("ME").transform.position.x - 3.5f < A_borderLeft)//不能往左
            {
                gameObject.transform.position = new Vector3(A_borderLeft + 3.5f, gameObject.transform.position.y, -10f);
                stopX = true;
            }
            if (playerAt == "A" && GameObject.Find("ME").transform.position.y + 2f > A_borderTop)//不能往上
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, A_borderTop - 2f, -10f);
                stopY = true;
            }
            if (playerAt == "A" && GameObject.Find("ME").transform.position.y - 2f < A_borderBottom)//不能往下
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, A_borderBottom + 2f, -10f);
                stopY = true;
            }
            ///
            /// ---------------------B
            ///
            if (playerAt == "B" && GameObject.Find("ME").transform.position.x + 3.5f > B_borderRight)//不能往右
            {
                gameObject.transform.position = new Vector3(B_borderRight - 3.5f, gameObject.transform.position.y, -10f);
                stopX = true;
            }
            if (playerAt == "B" && GameObject.Find("ME").transform.position.x - 3.5f < B_borderLeft)//不能往左
            {
                gameObject.transform.position = new Vector3(B_borderLeft + 3.5f, gameObject.transform.position.y, -10f);
                stopX = true;
            }
            if (playerAt == "B" && GameObject.Find("ME").transform.position.y + 2f > B_borderTop)//不能往上
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, B_borderTop - 2f, -10f);
                stopY = true;
            }
            if (playerAt == "B" && GameObject.Find("ME").transform.position.y - 2f < B_borderBottom)//不能往下
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, B_borderBottom + 2f, -10f);
                stopY = true;
            }


            if (stopX == false)
            {
                gameObject.transform.position = new Vector3(GameObject.Find("ME").transform.position.x, gameObject.transform.position.y, -10f);
            }
            if (stopY == false)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, GameObject.Find("ME").transform.position.y, -10f);
            }
        }
        catch
        { }
    }
}
