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
    public int perfectPass = 0;
    public bool isSuperSpeedActive;

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
        
        if(isSuperSpeedActive) {
            if(!other.transform.GetComponent<Goal>()) {
                Destroy(other.transform.parent.gameObject);
                Debug.Log("Destroying Platform");
            }
        } else {
            DeathPart deathPart = other.transform.GetComponent<DeathPart>();
            if(deathPart)
                deathPart.HitDeathPart();
        }
        
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(Vector3.up * ballImpulseStrength, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);
        
        perfectPass = 0;
        isSuperSpeedActive = false;

        this.BallCollisionSubject.OnNext(Unit.Default);
    }

    private void Update() {
        if(perfectPass >= 3 && !isSuperSpeedActive) {
            isSuperSpeedActive = true;
            rigidBody.AddForce(Vector3.down * 10, ForceMode.Impulse);
        }
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
