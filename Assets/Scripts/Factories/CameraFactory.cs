using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFactory
{
    public CameraComponent SpawnCamera(Vector3 position)
    {
        var camera = GameObject.Instantiate(PrefabResolverUtility.CameraPrefab, position, Quaternion.identity);

        var cameraComponent = camera.AddComponent<CameraComponent>();
        Debug.Log(cameraComponent.tag);

        return cameraComponent;

    }
}
