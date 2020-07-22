using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public PlayerPooling pooling;
    public int  currentPool = 0;
    public Transform playerGunMuzzle;

    public float fireRate;
    public float nextFire;

    private void Start()
    {
        //Debug.Log("fireRate : " + fireRate);
    }
    private void FixedUpdate()
    {
        //Debug.Log("fireRate : " + fireRate);
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Debug.Log("fireRate : " + fireRate);
            //Debug.Log("next fire : " + nextFire);
            currentPool++;
            if (currentPool == pooling.bulletList.Count)
                currentPool = 0;
            pooling.bulletList[currentPool].transform.position = playerGunMuzzle.position;
            pooling.bulletList[currentPool].transform.rotation = playerGunMuzzle.rotation;
            pooling.bulletList[currentPool].SetActive(true);
        }
    }

}
