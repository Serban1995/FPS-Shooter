using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject bullet;

    public float rangeToTargetPlayer, timeBetweenShots;
    private float shotCounter;

    public Transform gun, firePoint, firePoint1;

    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTargetPlayer)
        {
            gun.LookAt(PlayerController.instance.transform.position + new Vector3(0f, 1.2f, 0));

            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                shotCounter = timeBetweenShots;
            }

        }
        else
        {
            shotCounter = timeBetweenShots;
            
            gun.rotation = Quaternion.Lerp(gun.rotation,Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10f, 0f), rotateSpeed * Time.deltaTime );
        }
    }
}
