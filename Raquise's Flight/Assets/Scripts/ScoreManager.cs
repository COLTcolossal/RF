using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text hiScoreText;
 

    int score = 0;
    int hiScore = 0;

    private void Awake()
    {
        instance = this;


    }

    void Start()
    {
        hiScore = PlayerPrefs.GetInt("hi-score", 0);
        scoreText.text = "SCORE: " + score.ToString();
        hiScoreText.text = "HI-SCORE: " + hiScore.ToString();
    }   

    void Update()
    {

    }

    public void AddPoint()
    {
        score += 100;
        scoreText.text = "SCORE: " + score.ToString();
        if (hiScore < score)
            PlayerPrefs.SetInt("hi-score", score);
    }

    public void AddPoint1()
    {
        score += 50;
        scoreText.text = "SCORE: " + score.ToString();
        if (hiScore < score)
            PlayerPrefs.SetInt("hi-score", score);
    }

    public void AddPoint2()
    {
        score += 1000;
        scoreText.text = "SCORE: " + score.ToString();
        if (hiScore < score)
            PlayerPrefs.SetInt("hi-score", score);
    }

}
