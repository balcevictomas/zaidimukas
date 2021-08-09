using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup2 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(20); 
            PlayerController.sfx[5].Play();
            Debug.Log("Picked");
            Destroy(this.gameObject, 0.1f);
        }
    }
}
