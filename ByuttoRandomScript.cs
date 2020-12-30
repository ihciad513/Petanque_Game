using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByuttoRandomScript : MonoBehaviour
{
    public GameObject byutto;
    bool once = true;
    public int byuttocount;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (once == true)
        {
            byuttocount += 1;
            if (byuttocount == 1)
            {
                once = false;
                Instabyutto();
            }
            
        }
        
    }
    void Instabyutto()
    {
        float x = Random.Range(-4.0f, 3.5f);
        float z = Random.Range(-2.0f, 10.0f);
        Instantiate(byutto, new Vector3(x, 1.9f, z), Quaternion.identity);
    }
}
