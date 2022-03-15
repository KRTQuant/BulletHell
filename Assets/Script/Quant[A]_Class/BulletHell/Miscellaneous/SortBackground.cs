using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortBackground : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField]
    private Transform bg1;
    [SerializeField]
    private Transform bg2;
    [SerializeField]
    private Transform bg3;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float bgHeight;

    private void Start()
    {
        bgHeight = bg1.gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        bg1.position = new Vector3(bg1.position.x, bg1.position.y, 0);
        bg2.position = new Vector3(bg2.position.x, bg1.position.y + bgHeight, 0);
        bg3.position = new Vector3(bg2.position.x, bg2.position.y + bgHeight, 0);
    }

    void Update()
    {
        //Debug.Log(bg1.name);
        bg1.transform.position -= transform.up * moveSpeed * Time.deltaTime;
        bg2.transform.position -= transform.up * moveSpeed * Time.deltaTime;
        bg3.transform.position -= transform.up * moveSpeed * Time.deltaTime;

        if(bg1.position.y <= -12.1f)
        {
            bg1.position = new Vector3(bg1.position.x, bg1.position.y + (3 * bgHeight), bg1.position.z);
        }
        if (bg2.position.y <= -12.1f)
        {
            bg2.position = new Vector3(bg2.position.x, bg2.position.y + (3 * bgHeight), bg2.position.z);
        }
        if (bg3.position.y <= -12.1f)
        {
            bg3.position = new Vector3(bg3.position.x, bg3.position.y + (3 * bgHeight), bg3.position.z);
        }
    }
}
