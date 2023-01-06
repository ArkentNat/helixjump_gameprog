using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public void LoadStage(int stageNumber, HelixComponent helixComponent, HelixLevelComponent helixLevelComponent)
    {
        var helixLevelFactory = new HelixLevelFactory();
        Debug.Log("StageNumber: " + stageNumber);
        Debug.Log("All Stages: " + helixComponent.GetAllStages().Count);
        
        //All Stages not read
        //Debug Line 62 - Video 2:56:00
        Stage stage = helixComponent.GetAllStages()[Mathf.Clamp(stageNumber, 0, helixComponent.GetAllStages().Count - 1)];
        Debug.Log("Stages: " + stage);
        if (stage == null) {
            Debug.LogError("No stage " + stageNumber + " found in allStages List. Are all stages assigned in the list?");
            return;
        }
    
        // Change Color of background of the stage
        Camera.main.backgroundColor = helixComponent.GetAllStages()[stageNumber].stageBackgroundColor;
    
        // Change Color of the ball in the stage
        FindObjectOfType<BallComponent>().GetComponent<Renderer>().material.color = helixComponent.GetAllStages()[stageNumber].stageBallColor;
            
        // Reset helix rotation
        transform.localEulerAngles = helixComponent.GetStartRotation();
    
        // Destroy old levels if there are any
        foreach (HelixLevelComponent go in helixComponent.GetSpawnedLevel())
            Destroy(go);
    
        float levelDistance = helixComponent.GetHelixDistance() / stage.levels.Count;
        //float spawnPosY = helixComponent.topTransform.localPosition.y;
        float spawnPosY = 0;
            
        Debug.Log("Level Distance: " + levelDistance);
        Debug.Log("Helix Distance: " + helixComponent.GetHelixDistance());
        Debug.Log("Stage Levels Count: " + stage.levels.Count);
    
        for (int i = 0; i < stage.levels.Count; i++) {
            if (helixComponent.GetSpawnedLevel().Count <= 0)
            {
                helixLevelComponent = helixLevelFactory.SpawnHelixLevel(helixComponent.transform.position);
                //GameObject level = Instantiate(helixLevelPrefab, transform);
                Debug.Log("Levels Spawned");
                helixLevelComponent.transform.localPosition = new Vector3(0, 17, 0);           
                helixComponent.SetHelixDistance(helixLevelComponent.transform.localPosition.y - helixComponent.goalComponent.transform.localPosition.y);
                helixComponent.AddSpawnedLevel(helixLevelComponent);
                spawnPosY = helixLevelComponent.transform.localPosition.y;
            }
            else
            {
                spawnPosY -= levelDistance;
                helixLevelComponent = helixLevelFactory.SpawnHelixLevel(helixComponent.transform.position);
                //GameObject level = Instantiate(helixLevelPrefab, transform);
                Debug.Log("Levels Spawned");
                helixLevelComponent.transform.localPosition = new Vector3(0, spawnPosY, 0);
                helixComponent.AddSpawnedLevel(helixLevelComponent);
    
                int partsToDisable = 12 - stage.levels[i].partCount;
                List<GameObject> disabledParts = new List<GameObject>();
    
                while(disabledParts.Count < partsToDisable) {
                    GameObject randomPart = helixLevelComponent.transform.GetChild(Random.Range(0, helixLevelComponent.transform.childCount)).gameObject;
                
                    if(!disabledParts.Contains(randomPart)) {
                        randomPart.SetActive(false);
                        disabledParts.Add(randomPart);
                    }
                }
    
                List<GameObject> leftParts = new List<GameObject>();
    
                foreach (Transform t in helixLevelComponent.transform) {
                    t.GetComponent<Renderer>().material.color = helixComponent.GetAllStages()[stageNumber].stageLevelPartColor;
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
}
