using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BallComponent : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float ballImpulseStrength = 1.8f;
    
    private Subject<Unit> BallCollisionSubject;

    public IObservable<Unit> OnBallCollidedObservable
    {
        get
        {
            return this.BallCollisionSubject.AsObservable();
        }
    }

    BallComponent()
    {
        this.BallCollisionSubject = new Subject<Unit>();
    }

    private void Start()
    {
        this.rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    public void EnableGravity()
    {
        this.rigidBody.useGravity = true;
    }
    
    //Event

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Ball collided with something");
        //this.BallCollisionSubject.OnNext(Unit.Default);
        
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(Vector3.up * ballImpulseStrength, ForceMode.Impulse);
    }
}
