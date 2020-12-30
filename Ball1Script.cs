using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball1Script : MonoBehaviour
{
    GameObject Fill;
    GameManagerScript1 script;

    float angle;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
        
       Fill = GameObject.Find("GameManager");
       script = Fill.GetComponent<GameManagerScript1>();
       float forceM = script.forceMagnitude;
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

