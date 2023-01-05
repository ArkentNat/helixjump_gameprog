using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int best;
    public int score;

    public int currentStage = 0;

    public GameOverScreen GameOverScreen;

    public static GameManager singleton;
    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null) {
            singleton = this;
        } else if (singleton != this) {
            Destroy(gameObject);
        }

        best = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel(){
        Debug.Log("Next Level Called");
    }

    public void RestartLevel(){
        Debug.Log("Game Over");
        singleton.score = 0;
        FindObjectOfType<BallComponent>().ResetBall();
    }



    public void AddScore (int scoreToAdd) {
        score += scoreToAdd;


        if(score > best) {
            best = score;
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return best;
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

}
