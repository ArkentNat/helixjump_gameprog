using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialResolverUtility : MonoBehaviour
{
    [SerializeField] private PhysicMaterial ballPhysicMaterial;

    private static PhysicMaterial ballPhysicMaterialStatic;

    private void Awake()
    {
        MaterialResolverUtility.ballPhysicMaterialStatic = ballPhysicMaterial;
    }

    public static PhysicMaterial BallPhysicMaterial
    {
        get
        {
            return MaterialResolverUtility.ballPhysicMaterialStatic;
        }
    }
}
