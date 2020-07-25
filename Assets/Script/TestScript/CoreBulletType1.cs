using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpecialBullet : MonoBehaviour
{
    public GameObject player;
    public GameObject turret;
    public float distTurretAndPlayer;
    public float distBulletAndPlayer;
    public float currentDis;

    void Start()
    {
        distTurretAndPlayer = Vector2.Distance(player.transform.position, turret.transform.position);
        distBulletAndPlayer = Vector2.Distance(player.transform.position, transform.position);
        //Debug.Log("distance Turret and player " + distTurretAndPlayer);
        Debug.Log("distance Turret and player / 2  :" + distTurretAndPlayer / 2);
        //Debug.Log("distance Bullet and player " + distBulletAndPlayer);
    }

    private void Update()
    {
        DebugFunction();
        currentDis = Vector2.Distance(player.transform.position, transform.position);
        GameObject childBullet = null;
        GameObject[] relateBullet = GameObject.Find("CoreBullet").GetComponentInChildren<GameObject[]>();
        if(currentDis < distTurretAndPlayer/2)
        {
            Debug.Log("Distance between this bullet and player < half of distance between turret and player");
            //Active bullet effect
        }
    }

    void GetBulletInChild()
    {

    }

    void DebugFunction()
    {
        Debug.DrawLine(turret.transform.position, player.transform.position);
        Debug.DrawLine(turret.transform.position, (player.transform.position / 2), Color.red);
    }
}
