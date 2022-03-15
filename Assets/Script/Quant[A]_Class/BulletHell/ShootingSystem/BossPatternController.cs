using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPatternController : MonoBehaviour
{
    [Header("Pattern 1 Properties")]
    private int bulletOrderPattern1 = 0;
    public float projectileSpeed;
    public float fireRate_type1;
    private float nextFire_type1 = 0f;

    [Header("Pattern 2 Properties")]
    private int bulletOrderPattern2 = 0;
    public float fireRate_type2;
    private float nextFire_type2 = 0f;
    public float angle;


    [Header("Reference")]
    public DynamicPooling dynamicPooling;
    public Transform bossPos;
    public Transform playerPos;
    public BossStatus bossStatus;

    private void Start()
    {
        InvokeRepeating("BossGunPattern1", 5f, 1f);
        //InvokeRepeating("BossGunPattern2", 3f, 0.5f);
    }

    private void Update()
    {
        /*if (Time.time > fireRate_type1)
        {
            nextFire_type1 = Time.time + fireRate_type1;
            BossGunPattern1();
        }
        if (Time.time > fireRate_type2)
        {
            nextFire_type2 = Time.time + fireRate_type2;
            BossGunPattern2();
        }*/

        if (bossStatus.currentHealth <= 0)
        {
            CancelInvoke("BossGunPattern1");
            SceneManager.LoadScene(0);
            Debug.Log("BossDead");
        }
    }

    private void BossGunPattern1()
    {
        Vector2 bulletDir;

        bulletDir = (playerPos.position - bossPos.position).normalized * projectileSpeed;
        //Debug.Log(bulletDir);

        dynamicPooling.objectToLists[1].list[bulletOrderPattern1].transform.position = transform.position;
        dynamicPooling.objectToLists[1].list[bulletOrderPattern1].transform.rotation = transform.rotation;
        dynamicPooling.objectToLists[1].list[bulletOrderPattern1].GetComponent<BossPatternOneBullet>().RecieveMoveDirPattern1(bulletDir);
        dynamicPooling.objectToLists[1].list[bulletOrderPattern1].SetActive(true);

        bulletOrderPattern1++;

        if (bulletOrderPattern1 >= 200)
            bulletOrderPattern1 = 0;
    }

    private void BossGunPattern2()
    {
        float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulletVector = new Vector2(bulletDirX, bulletDirY);
        Vector2 bulletDir = (bulletVector - bossPos.position).normalized;

        dynamicPooling.objectToLists[2].list[bulletOrderPattern2].transform.position = transform.position;
        dynamicPooling.objectToLists[2].list[bulletOrderPattern2].transform.rotation = transform.rotation;
        dynamicPooling.objectToLists[2].list[bulletOrderPattern2].GetComponent<BossPatternTwoBullet>().RecieveMoveDirPattern2(bulletDir);
        dynamicPooling.objectToLists[2].list[bulletOrderPattern2].SetActive(true);

        angle += 10f;
        bulletOrderPattern2++;

        if (bulletOrderPattern2 >= 200)
            bulletOrderPattern2 = 0;
    }
}
