using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenFactory
{
    public GameOverScreenComponent SpawnGameOverScreen()
    {
        var gameOverScreen = GameObject.Instantiate(
            PrefabResolverUtility.ScoreCounterPrefab,
            Vector3.zero,
            Quaternion.identity
        );

        var gameOverScreenComponent = gameOverScreen.AddComponent<GameOverScreenComponent>();

        return gameOverScreenComponent;
    }
}
