using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool stopX= false;
        bool stopY = false;
        float borderTop = PlayerPrefs.GetFloat("borderTop");
        float borderRight = PlayerPrefs.GetFloat("borderRight");
        float borderBottom = PlayerPrefs.GetFloat("borderBottom");
        float borderLeft = PlayerPrefs.GetFloat("borderLeft");
        try
        {
            if (GameObject.Find("ME").transform.position.x + 3.5f > borderRight)//不能往右
            {
                gameObject.transform.position = new Vector3(borderRight - 3.5f, gameObject.transform.position.y, -10f);
                stopX = true;
            }
            if (GameObject.Find("ME").transform.position.x - 3.5f < borderLeft)//不能往左
            {
                gameObject.transform.position = new Vector3(borderLeft + 3.5f, gameObject.transform.position.y, -10f);
                stopX = true;
            }
            if (GameObject.Find("ME").transform.position.y + 2f > borderTop)//不能往上
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, borderTop - 2f, -10f);
                stopY = true;
            }
            if (GameObject.Find("ME").transform.position.y - 2f < borderBottom)//不能往下
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, borderBottom + 2f, -10f);
                stopY = true;
            }
            if(stopX == false)
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
