using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random=UnityEngine.Random;

public class HelixComponent : MonoBehaviour
{
    [SerializeField] private float numberOfObstacleLevel = 0f;
    private Vector2 lastTapPosition;
    private Vector3 startRotation;
    
    public HelixGoalComponent goalComponent;
    
    private float helixDistance;
    private List<HelixLevelComponent> spawnedLevels = new List<HelixLevelComponent>();
    public List<Stage> allStages = new List<Stage>();
    
    private Subject<Unit> HelixOnAwakeSubject;

    public IObservable<Unit> HelixOnAwakeObservable
    {
        get
        {
            return this.HelixOnAwakeSubject.AsObservable();
        }
    }

    HelixComponent()
    {
        this.HelixOnAwakeSubject = new Subject<Unit>();
    }

    
    private void Awake()
    {
        startRotation = transform.localEulerAngles;
        //helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
        Debug.Log("I am awake");
        this.HelixOnAwakeSubject.OnNext(Unit.Default);
    }
    
    public void setNumberOfObstacleLevel(float numberOfObstacleLevel)
    {
        this.numberOfObstacleLevel = numberOfObstacleLevel;
    }
    

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPosition = Input.mousePosition;

            if (lastTapPosition == Vector2.zero)
            {
                lastTapPosition = currentTapPosition;
            }

            float delta = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition = currentTapPosition;
        
            transform.Rotate(Vector3.up * delta);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPosition = Vector2.zero;
        }
    }

    public float GetHelixDistance()
    {
        return this.helixDistance;
    }

    public void SetHelixDistance(float distance)
    {
        this.helixDistance = distance;
    }
    public Vector3 GetStartRotation()
    {
        return this.startRotation;
    }

    public List<HelixLevelComponent> GetSpawnedLevel()
    {
        return this.spawnedLevels;
    }

    public void AddSpawnedLevel(HelixLevelComponent helixLevelComponent)
    {
        this.spawnedLevels.Add(helixLevelComponent);
    }

    public List<Stage> GetAllStages()
    {
        return this.allStages;
    }

    public void SetStages(List<Stage> stages)
    {
        this.allStages = stages;
    }

    
}
