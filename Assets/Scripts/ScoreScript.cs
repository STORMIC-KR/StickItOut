using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int score = 0;
    public Text scoreDisplay;
    public Text highScoreText;

    private int savedScore = 0;
    private string hardKeyString = "HighScore";

    void Awake()
    {
        savedScore = PlayerPrefs.GetInt(hardKeyString, 0);
        highScoreText.text = "HIGH : " + savedScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "SCORE : " + score;

        if(score > savedScore)
        {
            PlayerPrefs.SetInt(hardKeyString, score);
        }
    }
}
