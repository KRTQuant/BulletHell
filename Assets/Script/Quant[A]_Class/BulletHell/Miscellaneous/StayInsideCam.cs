using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInsideCam : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -7.5f, 7.5f),
            Mathf.Clamp(transform.position.y, -4.7f, 4.7f),
            transform.position.z);
    }
}
