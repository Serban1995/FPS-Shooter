using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealthController : MonoBehaviour
{

    public int currentHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySoundEffects(1);
            //Cursor.lockState = CursorLockMode.None;

           // SceneManager.LoadScene("GameWin");
        }
    }
}
