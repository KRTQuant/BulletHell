using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyShootPlayer : MonoBehaviour
{
    //---------------------------- Transform --------------------------------
    public Transform enemyGunMuzzleLeft;
    public Transform enemyGunMuzzleRight;
    public Transform enemyGunHomingTurret;
    //---------------------------- Reference --------------------------------
    [SerializeField]
    private EnemyPooling pooling;
    //---------------------------- Normal Shooting System -------------------
    [SerializeField]
    public bool gunLeft;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float nextFire;
    [SerializeField]
    private int currentPool;
    //----------------------------- Homing Shooting System -------------------
    [SerializeField]
    private float homingFireRate;
    [SerializeField]
    private float homingNextFire;
    private int homingCurrentPool;

    private void Start()
    {
        pooling = GameObject.Find("PoolingScriptHolder").GetComponent<EnemyPooling>();
    }

    private void Update()
    {

        TurnTurret(); //Turn turret
        if (Time.time > nextFire) //Controll fire rate
        {
            nextFire = Time.time + fireRate;
            Shooting();
        }

        if (Time.time > homingNextFire)
        {
            homingNextFire = Time.time + homingFireRate;
            HomingTurret();
        }
    }

    private void Shooting()
    {
        currentPool++;
        if (currentPool >= pooling.normalBulletList.Count)
            currentPool = 0;
        if (gunLeft == true)
        {
            //Debug.Log("Current pool : " + currentPool);
            pooling.normalBulletList[currentPool].transform.position = enemyGunMuzzleLeft.transform.position;
            pooling.normalBulletList[currentPool].transform.rotation = enemyGunMuzzleLeft.transform.rotation;
            //Debug.Log("Spawn at left");
            gunLeft = false;
        }
        else if(gunLeft == false)
        {
            //Debug.Log("Current pool : " + currentPool);
            pooling.normalBulletList[currentPool].transform.position = enemyGunMuzzleRight.transform.position;
            pooling.normalBulletList[currentPool].transform.rotation = enemyGunMuzzleRight.transform.rotation;
            //Debug.Log("Spawn at right");
            gunLeft = true;
        }
        pooling.normalBulletList[currentPool].SetActive(true);
    }

    private void TurnTurret()
    {
        Transform gunLeftTrans = GameObject.Find("GunMuzzleLeft").GetComponent<Transform>();
        Transform gunRightTrans = GameObject.Find("GunMuzzleRight").GetComponent<Transform>();
        Transform player = GameObject.Find("PlayerShip").GetComponent<Transform>();

        Vector3 dirGunLeft = player.position - gunLeftTrans.position;
        Vector3 dirGunRight = player.position - gunRightTrans.position;

        float angleGunLeft = Mathf.Atan2(dirGunLeft.x, -dirGunLeft.y) * Mathf.Rad2Deg;
        float angleGunRight = Mathf.Atan2(dirGunRight.x, -dirGunRight.y) * Mathf.Rad2Deg;

        Rigidbody2D gunLeftRb = GameObject.Find("GunMuzzleLeft").GetComponent<Rigidbody2D>();
        Rigidbody2D gunRightRb = GameObject.Find("GunMuzzleRight").GetComponent<Rigidbody2D>();

        gunLeftRb.rotation = angleGunLeft;
        gunRightRb.rotation = angleGunRight;
    }

    private void HomingTurret()
    {
        homingCurrentPool++;
        pooling.homingBulletList[currentPool].transform.position = enemyGunHomingTurret.transform.position;
        pooling.homingBulletList[currentPool].transform.rotation = enemyGunHomingTurret.transform.rotation;
        Debug.Log("Homing bullet spawn");
        pooling.homingBulletList[currentPool].SetActive(true);
    }
}
