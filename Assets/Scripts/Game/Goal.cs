using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("GOALLL");
        GameManager.singleton.NextLevel();
    }
}
