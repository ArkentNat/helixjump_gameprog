using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private BallComponent ballComponent;
    private CameraComponent cameraComponent;
    private HelixComponent helixComponent;
    private ScoreCounterComponent scoreCounterComponent;
    private HelixLevelComponent helixLevelComponent;
    private HelixGoalComponent helixGoalComponent;
    private StageManager stageManager;
    
    public List<Stage> levelStages = new List<Stage>();

    private EventManager eventManager;

    private void Start()
    {
        var ballFactory = new BallFactory();
        var cameraFactory = new CameraFactory();
        var helixFactory = new HelixFactory();
        var scoreCounterFactory = new ScoreCounterFactory();

        this.ballComponent = ballFactory.SpawnBall(new Vector3(0, 17, 1));
        this.cameraComponent = cameraFactory.SpawnCamera(new Vector3(0, 19, 4));
        this.cameraComponent.transform.Rotate(30,-180,0);
        this.helixComponent = helixFactory.SpawnHelix((new Vector3(0, 0, 0)));
        this.helixComponent.SetStages(levelStages);
        
        this.scoreCounterComponent = scoreCounterFactory.SpawnScoreCounter();
        
        this.cameraComponent.addBallTarget(this.ballComponent);
    
        this.RegisterEvents();
    }

    private void RegisterEvents()
    {
        helixComponent.HelixOnAwakeObservable.Subscribe((_) =>
        {
            Debug.Log("Helix is awake");
            stageManager.LoadStage(0, helixComponent);
        });

        //this.helixGoalComponent.OnGoalObstacleCollisionObservable.Subscribe((_) =>
        //{
            //GameManager.singleton.currentStage++;
            //this.ballComponent.ResetBall();
            //this.stageManager.LoadStage(GameManager.singleton.currentStage, this.helixComponent, this.helixLevelComponent);
        //});


        this.ballComponent.OnBallCollidedObservable.Subscribe((_) =>
        {
            GameManager.singleton.AddScore(1);
            this.scoreCounterComponent.Increase();
        });

        GameManager.singleton.OnRestartLevelObservable.Subscribe((_) =>
        {
            this.ballComponent.ResetBall();
            this.stageManager.LoadStage(GameManager.singleton.currentStage, this.helixComponent);
        });
    }
    
    
}
