using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternOneBullet : MonoBehaviour
{
    //----------------- Reference
    public Rigidbody2D rb;
    public Vector2 bulletDir;

    public void RecieveMoveDirPattern1(Vector2 moveDir)
    {
        bulletDir = moveDir;
    }

    private void Update()
    {
        rb.velocity = new Vector2(bulletDir.x, bulletDir.y);
    }
}
