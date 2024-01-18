using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public int highscore;
    public Text scoreText;
    public Text menuScoreText;
    public Text menuHighscoreText;

    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        highscore = PlayerPrefs.GetInt("highscore");

        menuScoreText.text = "score: " + score.ToString();
        menuHighscoreText.text = "highscore: " + highscore.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    } 

    public void AddScore() 
    {
        score += 1;
    }

    public void SaveScore() 
    { 
        if (score > highscore) 
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        PlayerPrefs.SetInt("score", score);
    }
}
