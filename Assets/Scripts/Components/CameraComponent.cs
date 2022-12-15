using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{

    public BallComponent target;

    private float offset;

    private void Start()
    {
        Debug.Log(target.tag);
        offset = transform.position.y - target.transform.position.y;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = target.transform.position.y + offset;
        transform.position = currentPosition;
    }

    public void addBallTarget(BallComponent target)
    {
        this.target = target;
    }
}
