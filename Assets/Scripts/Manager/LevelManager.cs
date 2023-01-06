using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public BallComponent ballComponent;
    private CameraComponent cameraComponent;
    private HelixComponent helixComponent;
    private ScoreCounterComponent scoreCounterComponent;
    private GameOverScreen gameOverScreenComponent;

    private EventManager eventManager;

    private void Start()
    {
        var ballFactory = new BallFactory();
        var cameraFactory = new CameraFactory();
        var helixFactory = new HelixFactory();
        var scoreCounterFactory = new ScoreCounterFactory();
        var gameOverScreenFactory = new GameOverScreenFactory();

        this.ballComponent = ballFactory.SpawnBall(new Vector3(0, 17, 1));
        this.cameraComponent = cameraFactory.SpawnCamera(new Vector3(0, 19, 4));
        this.cameraComponent.transform.Rotate(30,-180,0);
        this.helixComponent = helixFactory.SpawnHelix((new Vector3(0, 0, 0)));
        this.scoreCounterComponent = scoreCounterFactory.SpawnScoreCounter();
        
        this.cameraComponent.addBallTarget(this.ballComponent);
        
        this.RegisterEvents();
    }

    private void RegisterEvents()
    {
        this.ballComponent.OnBallCollidedObservable.Subscribe((_) =>
        {
            GameManager.singleton.AddScore(1);
            this.scoreCounterComponent.Increase();
        });

        this.gameOverScreenComponent = gameOver

    }
}
