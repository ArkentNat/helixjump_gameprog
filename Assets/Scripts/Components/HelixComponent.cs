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

    public Transform topTransform;
    public Transform goalTransform;
    public GameObject helixLevelPrefab;

    private float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();
    public List<Stage> allStages = new List<Stage>();


    private void Awake()
    {
        startRotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
        LoadStage(0);
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

    public void LoadStage(int stageNumber) {
        Debug.Log("StageNumber: " + stageNumber);
        Debug.Log("All Stages: " + allStages.Count);

        //Debug Line 62 - Video 2:56:00
        //All Stages not read
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];
        Debug.Log("Stages: " + stage);
        if (stage == null) {
            Debug.LogError("No stage " + stageNumber + " found in allStages List. Are all stages assigned in the list?");
            return;
        }

        // Change Color of background of the stage
        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;

        // Change Color of the ball in the stage
        FindObjectOfType<BallComponent>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;
        
        // Reset helix rotation
        transform.localEulerAngles = startRotation;

        // Destroy old levels if there are any
        foreach (GameObject go in spawnedLevels)
            Destroy(go);

        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;
        
        Debug.Log("Level Distance: " + levelDistance);
        Debug.Log("Helix Distance: " + helixDistance);
        Debug.Log("Stage Levels Count: " + stage.levels.Count);

        for (int i = 0; i < stage.levels.Count; i++) {
            spawnPosY -= levelDistance;
            GameObject level = Instantiate(helixLevelPrefab, transform);
            Debug.Log("Levels Spawned");
            level.transform.localPosition = new Vector3(0, spawnPosY, 0);
            spawnedLevels.Add(level);

            int partsToDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disabledParts = new List<GameObject>();

            while(disabledParts.Count < partsToDisable) {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
            
                if(!disabledParts.Contains(randomPart)) {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
            }

            List<GameObject> leftParts = new List<GameObject>();

            foreach (Transform t in level.transform) {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if(t.gameObject.activeInHierarchy)
                    leftParts.Add(t.gameObject);
            }

            List<GameObject> deathParts = new List<GameObject>();

            while(deathParts.Count < stage.levels[i].deathPartCount) {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];
                if(!deathParts.Contains(randomPart)) {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathParts.Add(randomPart);
                }
            }

        }
    }
}
