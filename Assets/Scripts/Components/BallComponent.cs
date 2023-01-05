using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BallComponent : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float ballImpulseStrength = 2.8f;
    
    private bool ignoreNextCollision;
    
    private Subject<Unit> BallCollisionSubject;
    private Vector3 startPos;

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

    void Awake() {
        startPos = transform.position;
    }

    public void EnableGravity()
    {
        this.rigidBody.useGravity = true;
    }
    
    //Event

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log("Ball collided with something");
        //this.BallCollisionSubject.OnNext(Unit.Default);
        if(ignoreNextCollision)
            return; 

        DeathPart deathPart = other.transform.GetComponent<DeathPart>();
        if(deathPart)
            deathPart.HitDeathPart();
        
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(Vector3.up * ballImpulseStrength, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        //Dave F-07
        // GameManager.singleton.AddScore(1);
        // Debug.Log(GameManager.singleton.score);
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }
}
