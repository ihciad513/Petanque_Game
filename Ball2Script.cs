using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2Script : MonoBehaviour
{
    GameObject Fill;
    GameManagerScript2 script2;

    float angle;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
        
       Fill = GameObject.Find("GameManager");
       script2 = Fill.GetComponent<GameManagerScript2>();
       float forceM = script2.forceMagnitude;
        if (Fill.transform.localEulerAngles.y> 180)
        {
            angle = Fill.transform.localEulerAngles.y-360;
        }
        if (Fill.transform.localEulerAngles.y < 180)
        {
            angle = Fill.transform.localEulerAngles.y;
        }
     
       
       Rigidbody rb = GetComponent<Rigidbody>();
       Vector3 force = new Vector3((angle*6)/45, forceM*0.9f, forceM*1.0f);
       rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

