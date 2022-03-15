using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    //----------------- Reference --------------------------
    [Header("Reference")]
    [SerializeField]
    private DynamicPooling dynamicPooling;
    [SerializeField]
    private Transform p_Left_Gun;
    [SerializeField]
    private Transform p_Mid_Gun;
    [SerializeField]
    private Transform p_Right_Gun;
    [SerializeField]
    private GameObject leftMinions;
    [SerializeField]
    private GameObject rightMinions;

    //----------------- Variable ---------------------------
    [Header("Buulet Type 1 Property")]
    [SerializeField]
    private float fireRate1 = 10;
    [SerializeField]
    private float lastFired1;
    [SerializeField]
    private int bulletOrder1 = 0;    
    [Header("Bullet Type 2 Property")]
    [SerializeField]
    private float fireRate2 = 10;
    [SerializeField]
    private float lastFired2;
    [SerializeField]
    private int bulletOrder2 = 0;
    [Header("Bullet Type 3 Property")]
    [SerializeField]
    private float fireRate3 = 10;
    [SerializeField]
    private float lastFired3;
    [SerializeField]
    private int bulletOrder3 = 0;

    [SerializeField]
    private enum typeOfGun { SINGLEBULLET, DOUBLEBULLET, TRIPLEBULLET};
    [Header("Gun type property")]
    [SerializeField]
    private typeOfGun gunType;
    [SerializeField]
    private int upgradeCollected = 1;
    [SerializeField]
    bool isLeftDead = false;
    [SerializeField]
    bool isRightDead = false;

    private void Awake()
    {
/*        dynamicPooling = GameObject.Find("PoolingHolder").GetComponent<DynamicPooling>();
        p_Mid_Gun = GameObject.Find("p_Mid_Gun").GetComponent<Transform>();
        p_Left_Gun = GameObject.Find("p_Left_Gun").GetComponent<Transform>();
        p_Right_Gun = GameObject.Find("p_Right_Gun").GetComponent<Transform>();*/
    }

    private void Update()
    {
        if (upgradeCollected == 3)
        {
            gunType = typeOfGun.TRIPLEBULLET;
        }
        else if (upgradeCollected == 2)
        {
            gunType = typeOfGun.DOUBLEBULLET;
        }
        else if (upgradeCollected == 1)
        {
            gunType = typeOfGun.SINGLEBULLET;
        }
            
        if (Time.time - lastFired1 > 1 / fireRate1 && gunType == typeOfGun.SINGLEBULLET)
        {
            if (bulletOrder1 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder1 = 0;
            }   

            lastFired1 = Time.time;
            dynamicPooling.objectToLists[0].list[bulletOrder1].transform.position = p_Mid_Gun.transform.position;
            dynamicPooling.objectToLists[0].list[bulletOrder1].transform.rotation = p_Mid_Gun.transform.rotation;
            dynamicPooling.objectToLists[0].list[bulletOrder1].SetActive(true);
            bulletOrder1++;
        }

        else if (Time.time - lastFired2 > 1 / fireRate2 && gunType == typeOfGun.DOUBLEBULLET)
        {
            lastFired2 = Time.time;
            dynamicPooling.objectToLists[0].list[bulletOrder2].transform.position = p_Left_Gun.transform.position;
            dynamicPooling.objectToLists[0].list[bulletOrder2].transform.rotation = p_Left_Gun.transform.rotation;
            dynamicPooling.objectToLists[0].list[bulletOrder2].SetActive(true);
            bulletOrder2++;
            if (bulletOrder2 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder2 = 0;
            }
            lastFired2 = Time.time;
            dynamicPooling.objectToLists[0].list[bulletOrder2].transform.position = p_Right_Gun.transform.position;
            dynamicPooling.objectToLists[0].list[bulletOrder2].transform.rotation = p_Right_Gun.transform.rotation;
            dynamicPooling.objectToLists[0].list[bulletOrder2].SetActive(true);
            bulletOrder2++;
            if (bulletOrder2 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder2 = 0;
            }
        }

        else if (Time.time - lastFired3 > 1 / fireRate3 && gunType == typeOfGun.TRIPLEBULLET)
        {
            if (bulletOrder3 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder3 = 0;
            }

            lastFired3 = Time.time;
            dynamicPooling.objectToLists[0].list[bulletOrder3].transform.position = p_Left_Gun.transform.position;
            dynamicPooling.objectToLists[0].list[bulletOrder3].transform.rotation = p_Left_Gun.transform.rotation;
            dynamicPooling.objectToLists[0].list[bulletOrder3].SetActive(true);
            bulletOrder3++;
            if (bulletOrder2 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder2 = 0;
            }
            lastFired3 = Time.time;
            dynamicPooling.objectToLists[0].list[bulletOrder3].transform.position = p_Mid_Gun.transform.position;
            dynamicPooling.objectToLists[0].list[bulletOrder3].transform.rotation = p_Mid_Gun.transform.rotation;
            dynamicPooling.objectToLists[0].list[bulletOrder3].SetActive(true);
            bulletOrder3++;
            if (bulletOrder2 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder2 = 0;
            }
            lastFired3 = Time.time;
            dynamicPooling.objectToLists[0].list[bulletOrder3].transform.position = p_Right_Gun.transform.position;
            dynamicPooling.objectToLists[0].list[bulletOrder3].transform.rotation = p_Right_Gun.transform.rotation;
            dynamicPooling.objectToLists[0].list[bulletOrder3].SetActive(true);
            bulletOrder3++;
            if (bulletOrder2 == dynamicPooling.objectToLists[0].poolingAmount)
            {
                bulletOrder2 = 0;
            }

        }

        //For test
        if(Input.GetKeyDown(KeyCode.Q))
        {
            upgradeCollected++;
        }

        if(leftMinions.activeSelf == false && isLeftDead == false   )
        {
            Debug.Log("Left should dead and get upgrade");
            upgradeCollected++;
            isLeftDead = true;
        }        
        if(rightMinions.activeSelf == false && isRightDead == false)
        {
            Debug.Log("right should dead and get upgrade");
            upgradeCollected++;
            isRightDead = true;
        }

    }
}
