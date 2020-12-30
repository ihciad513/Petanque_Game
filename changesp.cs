using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changesp : MonoBehaviour
{
    GameObject sphere;
    Renderer sphereinfo;
    

    void Start()
    {
        
        sphere = GameObject.Find("Byutto");
        sphereinfo = sphere.GetComponent<Renderer>();
    }

    void Update()
    {
       
    }
    public void OnClick()
    {
       sphereinfo.material.color =new Color(Random.value,Random.value,Random.value,1.0f); 
    }
}
