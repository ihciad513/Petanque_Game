using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneScript : MonoBehaviour
{
    public GameObject sound;
    

    public void StartButton()
    {
        Instantiate(sound);
       
        StartCoroutine(Ready());
    }

    public void SkipButton()
    {
        Instantiate(sound);
        StartCoroutine(Ready2());
    }

    IEnumerator Ready()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("ExplainScene");
    }
    IEnumerator Ready2()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainScene");
    }
}
