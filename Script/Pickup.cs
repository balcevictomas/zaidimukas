using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
     void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(10);
            PlayerController.sfx[4].Play();
            Debug.Log("Picked");
            Destroy(this.gameObject, 0.1f);
        }
    }
}
