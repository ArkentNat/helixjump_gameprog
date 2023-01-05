using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabResolverUtility : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject cameraPrefab;

    private static GameObject ballPrefabStatic;
    private static GameObject cameraPrefabStatic;

    private void Awake()
    {
        PrefabResolverUtility.ballPrefabStatic = ballPrefab;
        PrefabResolverUtility.cameraPrefabStatic = cameraPrefab;
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
}
