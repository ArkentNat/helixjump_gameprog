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
        this.cameraComponent = cameraFactory.SpawnCamera(new Vector3(0, 19, 4));
        this.cameraComponent.transform.Rotate(30,-180,0);
        
        this.cameraComponent.addBallTarget(this.ballComponent);
    }
}
