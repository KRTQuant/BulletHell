using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public List<GameObject> bulletList;
    private GameObject bulletEnemy;
    public GameObject EnemyBulletRef;

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
            bulletEnemy = Instantiate<GameObject>(EnemyBulletRef, bulletKeeper.position, Quaternion.identity);
            bulletList.Add(bulletEnemy);
            bulletEnemy.transform.parent = bulletParent;
            bulletEnemy.SetActive(false);
        }

        Debug.Log("bullet in enemy list's  = " + bulletList.Count);
        EnemyBulletRef.SetActive(false);
    }
}
