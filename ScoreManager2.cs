using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public Text scoretext2;
    int score;
    int score2;
    int score3;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("PS");
        score2 = PlayerPrefs.GetInt("PS2");
        score3 = score + score2;
        scoretext2.text = score3.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
