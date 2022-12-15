using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HelixComponent : MonoBehaviour
{

    [SerializeField] private float numberOfObstacleLevel = 0f;
    private Vector2 lastTapPosition;
    private Vector3 startRotation;

    private void Awake()
    {
        startRotation = transform.localEulerAngles;
        
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
}
