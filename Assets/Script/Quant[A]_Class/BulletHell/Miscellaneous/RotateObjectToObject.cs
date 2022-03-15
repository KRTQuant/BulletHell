using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectToObject : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    void RotateTurret()
    {
        // หาทิศทางของ Vector
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;

        rb.rotation = angle; // -90;
        dir.Normalize();
        //------------------------------    DebugZone   ----------------------------------
        //Debug.Log(angle);
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        Debug.DrawRay(transform.position, dir, Color.blue);
    }
}
