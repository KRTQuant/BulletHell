using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//------------------- Powered by KRT_Quant[A] -----------------------------------------------------------------------------
//------------------- Powered by KRT_Quant[A] -----------------------------------------------------------------------------
//------------------- Powered by KRT_Quant[A] -----------------------------------------------------------------------------
//------------------- Powered by KRT_Quant[A] -----------------------------------------------------------------------------

public class DynamicPooling : MonoBehaviour
{
    //----------------- Process Order -------------------------------------------------
    //----  0 - First time pooling - 0 ------------------------------------------------
    //----  1 - Check all visible in camera - 1  --------------------------------------
    //----  2 - Generate if current use are equal or more than pooling amount ---------
    public List<ObjectToList> objectToLists;

    private void Start()
    {
        //------------------------------------------- First time pooling ----------------------------------------------------------
        foreach (ObjectToList poolingInList in objectToLists)
        {
            if (poolingInList.baseObject == null)
            {
                return;
            }

            if (poolingInList.parent == null)
            {
                GameObject generatedParent = new GameObject("Parent of " + poolingInList.baseObject.name);
                poolingInList.parent = generatedParent.transform;
                generatedParent.transform.parent = this.transform;
            }

            if (poolingInList.storePosition == null)
            {
                GameObject generatedStore = new GameObject("object store position of " + poolingInList.baseObject.name);
                generatedStore.transform.position = new Vector3(0, 0);
                poolingInList.storePosition = generatedStore.transform;
                generatedStore.transform.parent = this.transform;
            }
            else
            {
                return;
            }

            for (int i = 0; i < poolingInList.poolingAmount; i++)
            {
                poolingInList.spawnObject = Instantiate<GameObject>(poolingInList.baseObject, poolingInList.parent.position, Quaternion.identity);
                poolingInList.list.Add(poolingInList.spawnObject);
                poolingInList.spawnObject.name = poolingInList.baseObject.name + i.ToString();
                poolingInList.spawnObject.transform.parent = poolingInList.parent;
                poolingInList.spawnObject.SetActive(false);
            }

            poolingInList.baseObject.SetActive(false);
        }
    }

    private void Update()
    {
        //------------------------------------------- Check visible object in Camera ------------------------------------------------------------------------
        //-------------------------------------------    -  Generate if all pooled object amount are visible in scene -     ---------------------------------
    }
}

[System.Serializable]
public class ObjectToList
{
    public List<GameObject> list;
    public GameObject baseObject;
    public GameObject spawnObject;
    public int poolingAmount;
    public Transform parent;
    public Transform storePosition;
}

/*
public class PoolingManager
{
}

public class PoolingObject : MonoBehaviour,IPoolable
{
    public string name;
    public Transform defaultPosition;

    public virtual void DoDestroy()
    {

    }

    public virtual IPoolable GetPoolableObject()
    {
        return this;
    }

}

public interface IPoolable
{
    void DoDestroy();

    IPoolable GetPoolableObject();
}
*/
