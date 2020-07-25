using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject turret;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relate = transform.InverseTransformPoint(player.transform.position);
        Debug.DrawLine(turret.transform.position, player.transform.position ,UnityEngine.Color.white);
        Debug.DrawLine(turret.transform.position, relate);
        Vector2 dir = player.transform.position - turret.transform.position;
        dir.Normalize();

    }
}
