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

    private static GameObject ballPrefabStatic;
    private static GameObject cameraPrefabStatic;
    private static GameObject helixPrefabStatic;
    private static GameObject scoreCounterPrefabStatic;

    private void Awake()
    {
        PrefabResolverUtility.ballPrefabStatic = ballPrefab;
        PrefabResolverUtility.cameraPrefabStatic = cameraPrefab;
        PrefabResolverUtility.helixPrefabStatic = helixPrefab;
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

    public static GameObject ScoreCounterPrefab
    {
        get
        {
            return PrefabResolverUtility.scoreCounterPrefabStatic;
        }
    }
}
