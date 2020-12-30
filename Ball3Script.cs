using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball3Script : MonoBehaviour
{
    GameObject Fill;
    GameManagerScript3 script3;

    float angle;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
        
       Fill = GameObject.Find("GameManager");
       script3 = Fill.GetComponent<GameManagerScript3>();
       float forceM = script3.forceMagnitude;
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

