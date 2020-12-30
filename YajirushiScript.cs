using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YajirushiScript : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    int fugo = 1;

    bool touch;
    void Start()
    {
        
    }

    
    void Update()
    {
        speed += Time.deltaTime * 100*fugo;
        this.transform.rotation = Quaternion.Euler(0, speed, 0);

        if (touch == true)
        {
            fugo = -1;
           // Debug.Log(transform.localEulerAngles.y);
        }
        else
        {
            fugo = 1;
        }

        if (this.transform.localEulerAngles.y > 45 && this.transform.localEulerAngles.y<50)
        {
            touch = true;
        }
        if(this.transform.localEulerAngles.y < 315 && this.transform.localEulerAngles.y>310)
        {
            touch = false;
        }
    }
}
