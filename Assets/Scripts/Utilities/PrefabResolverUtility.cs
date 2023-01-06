using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolverUtility : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private GameObject helixPrefab;
    [SerializeField] private GameObject helixGoalPrefab;
    [SerializeField] private GameObject helixLevelPrefab;
    [SerializeField] private GameObject scoreCounterPrefab;

    private static GameObject ballPrefabStatic;
    private static GameObject cameraPrefabStatic;
    private static GameObject helixPrefabStatic;
    private static GameObject helixGoalPrefabStatic;
    private static GameObject helixLevelPrefabStatic;
    private static GameObject scoreCounterPrefabStatic;

    private void Awake()
    {
        PrefabResolverUtility.ballPrefabStatic = ballPrefab;
        PrefabResolverUtility.cameraPrefabStatic = cameraPrefab;
        PrefabResolverUtility.helixPrefabStatic = helixPrefab;
        PrefabResolverUtility.helixGoalPrefabStatic = helixGoalPrefab;
        PrefabResolverUtility.helixLevelPrefabStatic = helixLevelPrefab;
        PrefabResolverUtility.scoreCounterPrefabStatic = scoreCounterPrefab;
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
    
    public static GameObject HelixGoalPrefab
    {
        get
        {
            return PrefabResolverUtility.helixGoalPrefabStatic;
        }
    }
    
    public static GameObject HelixLevelPrefab
    {
        get
        {
            return PrefabResolverUtility.helixLevelPrefabStatic;
        }
    }

    public static GameObject ScoreCounterPrefab
    {
        get
        {
            return PrefabResolverUtility.scoreCounterPrefabStatic;
        }
    }
}
