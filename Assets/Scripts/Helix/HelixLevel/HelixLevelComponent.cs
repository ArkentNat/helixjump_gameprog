using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HelixLevelComponent : MonoBehaviour
{
  private Subject<Unit> PassLevelSubject;

  public IObservable<Unit> OnLevelPassedObservable
  {
    get
    {
      return this.PassLevelSubject.AsObservable();
    }
  }

  HelixLevelComponent()
  {
    this.PassLevelSubject = new Subject<Unit>();
  }
  private void OnTriggerEnter(Collider other)
  {
    this.PassLevelSubject.OnNext(Unit.Default);
    
    //GameManager.singleton.AddScore(1);
    //FindObjectOfType<BallComponent>().perfectPass++;
    //Perfect Pass only read once -- PassCheck is not given in the HelixPartPrefab
    //Debug.Log("Perfect Pass is increased");
  }
}
