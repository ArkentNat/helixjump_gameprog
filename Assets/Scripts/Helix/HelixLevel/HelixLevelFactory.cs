using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixLevelFactory : MonoBehaviour
{
    public HelixLevelComponent SpawnHelixLevel(Vector3 position)
    {
        var helixLevel = GameObject.Instantiate(PrefabResolverUtility.HelixLevelPrefab, position, Quaternion.identity);

        var helixLevelComponent = helixLevel.AddComponent<HelixLevelComponent>();

        return helixLevelComponent;
    }
}
