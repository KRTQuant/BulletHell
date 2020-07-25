﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;
    private float countdown = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        Debug.Log(direction);
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = rotateAmount * rotationSpeed;

        rb.velocity = transform.up * -speed;
        countdown -= Time.fixedDeltaTime;
        if(countdown <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }
}