using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveGameManager : MonoBehaviour
{
    GameObject GameManager;

    public GameObject rightsound;
    public GameObject leftsound;

    bool right = false;
    bool left = false;

    void Start()
    {
   
    }
    void Update()
    {
        if (right)
        {
            goright();
            Instantiate(rightsound);
        }
        else if (left)
        {
            goleft();
            Instantiate(leftsound);
        }
    }

    public void rPushDown()
    {
        //右ボタンを押している間
        right = true;
    }

    public void rPushUp()
    {
        //右ボタンを押すのをやめた時
        right = false;
    }

    public void lPushDown()
    {
        //左ボタンを押している間
        left = true;
    }

    public void lPushUp()
    {
        //左ボタンを押すのをやめた時
        left = false;
    }

    public void goright()
    {
        if (transform.position.x <= 3.5f)
        {
            //プレイヤーの位置が3.5f以下の時
            transform.position += new Vector3(5.0f * Time.deltaTime, 0, 0);
            //プレイヤーをx軸方向に秒速5.0fで動かす
        }
    }

    public void goleft()
    {
        if (transform.position.x >= -3.5f)
        {
            //プレイヤーの位置が-3.5f以上の時
            transform.position += new Vector3(-5.0f * Time.deltaTime, 0, 0);
            //プレイヤーをx軸方向に秒速-5.0fで動かす
        }
    }

}

