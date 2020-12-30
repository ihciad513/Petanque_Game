using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoretext;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("PS");
        scoretext.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
