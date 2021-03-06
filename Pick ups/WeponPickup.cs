using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponPickup : MonoBehaviour
{

    public string theGun;
    
    private bool collected;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            PlayerController.instance.AddGun(theGun);
            
            Destroy(gameObject);

            collected = true;
            
            AudioManager.instance.PlaySoundEffects(3);
        }
    }
}
