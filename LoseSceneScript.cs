using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneScript : MonoBehaviour
{
    public GameObject Losesound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseScene() 
    { 
        Instantiate(Losesound);
        PlayerPrefs.DeleteAll();
        StartCoroutine(Ready());
    
    }
IEnumerator Ready()
{
    yield return new WaitForSeconds(1.0f);

    SceneManager.LoadScene("StartScene");
}
}
