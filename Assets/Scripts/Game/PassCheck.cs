using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
  private void OnTriggerEnter(Collider other) {
    GameManager.singleton.AddScore(1);
    FindObjectOfType<BallComponent>().perfectPass++;
    //Perfect Pass only read once -- PassCheck is not given in the HelixPartPrefab
    Debug.Log("Perfect Pass is increased");
  }
}
