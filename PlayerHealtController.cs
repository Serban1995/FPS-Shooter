using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{
    public static PlayerHealtController instace;

    public int maxHealth, currentHealth;

    public float invicibleLenght = 1f;
    private float invincCounter;
    
    // Start is called before the first frame update

    private void Awake()
    {
        instace = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0 && !GameManager.instance.levelEnding)
        {

            currentHealth -= damageAmount;
            AudioManager.instance.PlaySoundEffects(5);
            
            UIController.instance.ShowDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;
                
                GameManager.instance.PlayerDied();
                AudioManager.instance.StopBGM();
                AudioManager.instance.PlaySoundEffects(6);
                AudioManager.instance.StopSFX(5);
            }

            invincCounter = invicibleLenght;
            
            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
        
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }
}
