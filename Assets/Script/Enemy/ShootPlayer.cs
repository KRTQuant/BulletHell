using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public Transform enemyGunMuzzleLeft;
    public Transform enemyGunMuzzleRight;

    public Transform playerTransform;

    [SerializeField]
    public bool gunLeft;
    [SerializeField]
    private EnemyPooling pooling;
    [SerializeField]
    private int currentPool;

    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float nextFire;

    private void Start()
    {
        pooling = GameObject.Find("PoolingScriptHolder").GetComponent<EnemyPooling>();
        playerTransform = GameObject.Find("PlayerShip").GetComponent<Transform>();
    }

    private void Update()
    {
        TurnTurret();
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shooting();
        }
    }

    private void Shooting()
    {
        currentPool++;
        if (currentPool >= pooling.bulletList.Count)
            currentPool = 0;
        if (gunLeft == true)
        {
            //Debug.Log("Current pool : " + currentPool);
            pooling.bulletList[currentPool].transform.position = enemyGunMuzzleLeft.transform.position;
            pooling.bulletList[currentPool].transform.rotation = enemyGunMuzzleLeft.transform.rotation;
            Debug.Log("Spawn at left");
            gunLeft = false;
        }
        else if(gunLeft == false)
        {
            //Debug.Log("Current pool : " + currentPool);
            pooling.bulletList[currentPool].transform.position = enemyGunMuzzleRight.transform.position;
            pooling.bulletList[currentPool].transform.rotation = enemyGunMuzzleRight.transform.rotation;
            Debug.Log("Spawn at right");
            gunLeft = true;
        }
        pooling.bulletList[currentPool].SetActive(true);
    }

    private void TurnTurret()
    {

    }
}
