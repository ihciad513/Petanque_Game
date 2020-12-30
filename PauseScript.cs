using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pausebutton;
    public GameObject restartbutton;
    public GameObject pausepanel;

    // Start is called before the first frame update
    void Start()
    {
        pausepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausebutton.SetActive(false);
        restartbutton.SetActive(true);
        pausepanel.SetActive(true);
    }
    public void RestartButton()
    {
        pausepanel.SetActive(false);
        restartbutton.SetActive(false);
        pausebutton.SetActive(true);
        Time.timeScale = 1f;
    }
}
