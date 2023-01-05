using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public BallComponent ballComponent;
    private CameraComponent cameraComponent;

    private void Start()
    {
        var ballFactory = new BallFactory();
        var cameraFactory = new CameraFactory();

        this.ballComponent = ballFactory.SpawnBall(new Vector3(0, 17, 1));
        this.cameraComponent = cameraFactory.SpawnCamera(new Vector3(0, 17, 3));
        
        this.cameraComponent.addBallTarget(this.ballComponent);
    }
}
