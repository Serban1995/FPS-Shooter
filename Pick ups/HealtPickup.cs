using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPickup : MonoBehaviour
{

    public int healtAmount;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealtController.instace.HealPlayer(healtAmount);
            
            Destroy(gameObject);
            
            AudioManager.instance.PlaySoundEffects(4);
        }
    }
}
