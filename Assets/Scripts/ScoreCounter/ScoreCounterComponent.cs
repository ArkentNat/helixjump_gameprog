using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterComponent : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;

    private void Start()
    {
        this.scoreText = this.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        this.highScoreText = this.transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
    }
    
    public void Increase()
    {
        int scoreInInteger = int.Parse(this.scoreText.text) + 1;
        this.scoreText.text = GameManager.singleton.GetScore().ToString();

        highScoreText.text = "Best Score: " + GameManager.singleton.GetHighScore().ToString();
        

    }
}
