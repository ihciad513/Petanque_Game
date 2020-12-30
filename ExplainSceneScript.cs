using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExplainSceneScript : MonoBehaviour
{
    public GameObject sound;
    public GameObject Startbutton;
    public GameObject Ex1button;
    public GameObject Ex2button;
    public GameObject Ex3button;

    public GameObject Extext;
    public GameObject Extext2;
    public GameObject Extext3;
    public GameObject Extext4;

    void Start()
    {
        Startbutton.SetActive(false);
        Ex1button.SetActive(true);
        Ex2button.SetActive(false);
        Ex3button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Ex1Button()
    {
        Extext.SetActive(false);
        Extext2.SetActive(true);
        Ex1button.SetActive(false);
        Ex2button.SetActive(true);
    }

    public void Ex2Button()
    {
        Extext2.SetActive(false);
        Extext3.SetActive(true);
        Ex2button.SetActive(false);
        Ex3button.SetActive(true);
    }

    public void Ex3Button()
    {
        Extext3.SetActive(false);
        Ex3button.SetActive(false);
        Extext4.SetActive(true);
        Startbutton.SetActive(true);
    }

    public void ExplainScene()
    {
        Instantiate(sound);

        StartCoroutine(Ready());
        
    }
    IEnumerator Ready()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("MainScene");
    }
}
