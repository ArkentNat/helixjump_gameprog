using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private int currentStage = 0;
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        //SceneManager.LoadScene("Level1Scene");
        GameManager.singleton.score = 0;
        FindObjectOfType<BallComponent>().ResetBall();
        FindObjectOfType<HelixComponent>().LoadStage(GameManager.singleton.currentStage);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
