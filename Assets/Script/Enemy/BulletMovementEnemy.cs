using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementEnemy : MonoBehaviour
{
    public Rigidbody2D rigid;
    [SerializeField]
    private float bulletSpeed;
    private void Update()
    {
        //for test
        rigid.velocity = transform.up * bulletSpeed;
    }
}
