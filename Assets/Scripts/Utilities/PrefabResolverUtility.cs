using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolverUtility : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private GameObject helixPrefab;
    [SerializeField] private GameObject scoreCounterPrefab;
    [SerializeField] private GameObject gameOverScreenPrefab;

    private static GameObject ballPrefabStatic;
    private static GameObject cameraPrefabStatic;
    private static GameObject helixPrefabStatic;
    private static GameObject scoreCounterPrefabStatic;
    private static GameObject gameOverScreenStatic;

    private void Awake()
    {
        PrefabResolverUtility.ballPrefabStatic = ballPrefab;
        PrefabResolverUtility.cameraPrefabStatic = cameraPrefab;
        PrefabResolverUtility.helixPrefabStatic = helixPrefab;
        PrefabResolverUtility.scoreCounterPrefabStatic = scoreCounterPrefab;
        PrefabResolverUtility.gameOverScreenStatic = gameOverScreenPrefab;
    }

    public static GameObject BallPrefab
    {
        get
        {
            return PrefabResolverUtility.ballPrefabStatic;
        }
    }

    public static GameObject CameraPrefab
    {
        get
        {
            return PrefabResolverUtility.cameraPrefabStatic;
        }
    }
    
    public static GameObject HelixPrefab
    {
        get
        {
            return PrefabResolverUtility.helixPrefabStatic;
        }
    }

    public static GameObject ScoreCounterPrefab
    {
        get
        {
            return PrefabResolverUtility.scoreCounterPrefabStatic;
        }
    }
    
    public static GameObject GameOverScreenPrefab
    {
        get
        {
            return PrefabResolverUtility.gameOverScreenStatic;
        }
    }
}
