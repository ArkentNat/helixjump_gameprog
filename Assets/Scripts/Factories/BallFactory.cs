using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory
{
    public BallComponent SpawnBall(Vector3 position)
    {
        var ball = GameObject.Instantiate(PrefabResolverUtility.BallPrefab, position, Quaternion.identity);

        var rigidbody = ball.AddComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        var ballCollider = ball.GetComponent<SphereCollider>();
        ballCollider.material = MaterialResolverUtility.BallPhysicMaterial;
        

        var ballComponent = ball.AddComponent<BallComponent>();

        return ballComponent;

    }
}
