using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HelixGoalComponent : MonoBehaviour
{

    private Subject<Unit> OnGoalObstacleCollideSubject;

    public IObservable<Unit> OnGoalObstacleCollisionObservable
    {
        get
        {
            return this.OnGoalObstacleCollideSubject.AsObservable();
        }
    }

    HelixGoalComponent()
    {
        this.OnGoalObstacleCollideSubject = new Subject<Unit>();
    }
    
    private void OnCollisionEnter(Collision collision) {
        this.OnGoalObstacleCollideSubject.OnNext(Unit.Default);
        //Debug.Log("GOALLL");
        //GameManager.singleton.NextLevel();
    }
}
