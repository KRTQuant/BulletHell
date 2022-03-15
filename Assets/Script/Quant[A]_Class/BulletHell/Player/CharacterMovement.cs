using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform playerTransform;

    public Rigidbody2D rigid;

    public float speed;

    public float veloX;

    public float veloY;

    public int dir;

    public void Update()
    {
        SetDir();
        InputCenter();
        CalculateVelo(dir);
        if (rigid.transform.position.y >= 4.5f || rigid.transform.position.y <= -4.5f)
        {
            Debug.Log("Should stop walking");
        }
        if (rigid.transform.position.x >= 8.5f || rigid.transform.position.x <= -8.5f)
        {
            Debug.Log("Should stop walking");
        }
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -8.5f, 8.5f),
            Mathf.Clamp(transform.position.y, -4.5f, 4.5f),
            transform.position.z
        );
    }

    public void CalculateVelo(int dir)
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            veloX = speed * dir * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            veloY = speed * dir * Time.fixedDeltaTime;
    }

    public void InputCenter()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = new Vector2(0, veloY);
            //Debug.Log("keycode W");
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(veloX,0);
            //Debug.Log("keycode A");
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(0, veloY);
            //Debug.Log("keycode S");
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(veloX, 0);
            //Debug.Log("keycode D");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(veloX * Mathf.Sin(45 * Mathf.Deg2Rad), veloY * Mathf.Cos(45 * Mathf.Deg2Rad));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(veloX * Mathf.Sin(45 * Mathf.Deg2Rad), (veloY * -1) * Mathf.Sin(45 * Mathf.Deg2Rad));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2((veloX * -1) * Mathf.Sin(45 * Mathf.Deg2Rad), veloY * Mathf.Sin(45 * Mathf.Deg2Rad));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(veloX * Mathf.Sin(45 * Mathf.Deg2Rad), veloY * Mathf.Sin(45 * Mathf.Deg2Rad));
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            rigid.velocity = Vector2.zero;
            veloX = 0;
            veloY = 0;
        }
    }

    public void SetDir()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
            dir = 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
            dir = -1;
    }

    private void LimitMoveRange()
    {
        
    }
}
