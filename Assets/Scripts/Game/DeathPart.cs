using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

public class DeathPart : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    
    private void OnEnable() {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void HitDeathPart()
    {
        var gameOverScreenFactory = new GameOverScreenFactory();

        this.GameOverScreen = gameOverScreenFactory.SpawnGameOverScreen();
        this.GameOverScreen.Setup();
        //GameManager.singleton.RestartLevel();
    }
}