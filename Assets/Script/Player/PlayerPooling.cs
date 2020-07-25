using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPooling : MonoBehaviour
{
    public List<GameObject> bulletList;
    private GameObject bulletPlayer;
    public GameObject PlayerBulletRef;

    private Transform bulletKeeper;
    private Transform bulletParent;

    public int poolingAmount;

    private void Start()
    {
        bulletKeeper = GameObject.Find("BulletSpawnPos").GetComponent<Transform>();
        bulletParent = GameObject.Find("PlayerBulletParent").GetComponent<Transform>();

        for(int i = 0; i < poolingAmount; i++)
        {
            bulletPlayer = Instantiate<GameObject>(PlayerBulletRef, bulletKeeper.position, Quaternion.identity);
            bulletList.Add(bulletPlayer);
            bulletPlayer.transform.parent = bulletParent;
            bulletPlayer.SetActive(false);
        }
        //Debug.Log("bullet in player list's  = " + bulletList.Count);
        PlayerBulletRef.SetActive(false);
    }
}
