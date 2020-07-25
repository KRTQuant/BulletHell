using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public List<GameObject> normalBulletList;
    public List<GameObject> homingBulletList;
    private GameObject normalBulletEnemy;
    private GameObject homingBulletEnemy;

    public GameObject enemyBulletRef;
    public GameObject enemyHomingBulletRef;

    [SerializeField]
    private Transform bulletKeeper;
    [SerializeField]
    private Transform bulletParent;

    public int poolingAmount;

    private void Start()
    {
        bulletKeeper = GameObject.Find("BulletSpawnPos").GetComponent<Transform>();
        bulletParent = GameObject.Find("EnemyBulletParent").GetComponent<Transform>();

        for (int i = 0; i < poolingAmount; i++)
        {
            normalBulletEnemy = Instantiate<GameObject>(enemyBulletRef, bulletKeeper.position, Quaternion.identity);
            homingBulletEnemy = Instantiate<GameObject>(enemyHomingBulletRef, bulletKeeper.position, Quaternion.identity);
            normalBulletList.Add(normalBulletEnemy);
            homingBulletList.Add(homingBulletEnemy);
            normalBulletEnemy.transform.parent = bulletParent;
            homingBulletEnemy.transform.parent = bulletParent;
            normalBulletEnemy.SetActive(false);
            homingBulletEnemy.SetActive(false);
        }

        //Debug.Log("bullet in enemy list's  = " + normalBulletList.Count);
        //Debug.Log("bullet in enemy list's  = " + homingBulletList.Count);
        enemyBulletRef.SetActive(false);
        enemyHomingBulletRef.SetActive(false);
    }
}
