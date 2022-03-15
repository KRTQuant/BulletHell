using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsBulletPattern : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField]
    private float angle;
    [SerializeField]
    private int bulletOrderPattern;

    [Header("Reference")]
    [SerializeField]
    private DynamicPooling dynamicPooling;
    [SerializeField]
    private GameObject leftMinions;
    [SerializeField]
    private GameObject rightMinions;

    private void Start()
    {
        InvokeRepeating("MinionsBullet", 0.5f, 0.5f);
    }

    private void MinionsBullet()
    {
        if (gameObject.name == leftMinions.name)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((-angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((-angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector2(bulletDirX, bulletDirY);
            Vector2 bulletDir = (bulletVector - transform.position).normalized;

            dynamicPooling.objectToLists[2].list[bulletOrderPattern].transform.position = transform.position;
            dynamicPooling.objectToLists[2].list[bulletOrderPattern].transform.rotation = transform.rotation;
            dynamicPooling.objectToLists[2].list[bulletOrderPattern].GetComponent<BossPatternTwoBullet>().RecieveMoveDirPattern2(bulletDir);
            dynamicPooling.objectToLists[2].list[bulletOrderPattern].SetActive(true);

            angle += 10f;
            bulletOrderPattern++;

            if (bulletOrderPattern >= 200)
                bulletOrderPattern = 0;
        }

        else if(gameObject.name == rightMinions.name)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector2(bulletDirX, bulletDirY);
            Vector2 bulletDir = (bulletVector - transform.position).normalized;

            dynamicPooling.objectToLists[3].list[bulletOrderPattern].transform.position = transform.position;
            dynamicPooling.objectToLists[3].list[bulletOrderPattern].transform.rotation = transform.rotation;
            dynamicPooling.objectToLists[3].list[bulletOrderPattern].GetComponent<BossPatternTwoBullet>().RecieveMoveDirPattern2(bulletDir);
            dynamicPooling.objectToLists[3].list[bulletOrderPattern].SetActive(true);

            angle += 10f;
            bulletOrderPattern++;

            if (bulletOrderPattern >= 200)
                bulletOrderPattern = 0;
        }

    }
}
