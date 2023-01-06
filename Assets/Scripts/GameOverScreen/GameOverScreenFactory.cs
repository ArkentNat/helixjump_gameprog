using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenFactory : MonoBehaviour
{
    public GameOverScreen SpawnGameOverScreen()
    {
        var gameOver = GameObject.Instantiate(
            PrefabResolverUtility.GameOverScreenPrefab,
            Vector3.zero,
            Quaternion.identity
        );

        var gameOverComponent = gameOver.AddComponent<GameOverScreen>();

        return gameOverComponent;
    }
}
