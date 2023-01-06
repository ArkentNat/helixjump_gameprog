using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixFactory
{
    public HelixComponent SpawnHelix(Vector3 position)
    {
        var helix = GameObject.Instantiate(PrefabResolverUtility.HelixPrefab, position, Quaternion.identity);

        var helixComponent = helix.AddComponent<HelixComponent>();

        return helixComponent;
    } 
}
