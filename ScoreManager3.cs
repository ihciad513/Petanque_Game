using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager3 : MonoBehaviour
{
    public Text scoretext3;
    int score;
    int score2;
    int score3;
    int score4;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("PS");
        score2 = PlayerPrefs.GetInt("PS2");
        score3 = PlayerPrefs.GetInt("PS3");
        score4 = score + score2 + score3;
        scoretext3.text = score4.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
