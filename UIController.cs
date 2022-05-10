using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance;

    public Slider healthSlider;

    public Text healthText;

    public Text currentAmmoText;

    public Image damageEffect;
    public float damageAlpha = 0.25f, damageFade = 2f;

    public GameObject pauseScreen;

    public Image blackScreen;
    public float fadeSpeed;
   

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (damageEffect.color.a != 0)
        {
            damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b,
                Mathf.MoveTowards(damageEffect.color.a, 0f, damageFade * Time.deltaTime));
        }

        if (!GameManager.instance.levelEnding)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
        else
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }

    public void ShowDamage()
    {
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, damageAlpha);
    }
}
