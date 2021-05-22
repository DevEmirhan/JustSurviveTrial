using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform poolContainer;
    [SerializeField] private PoolObject objectPrefab;
    [SerializeField] private int minObjectCount = 16;
    [SerializeField] private int maxObjectCount = 24;

    public List<PoolObject> poolObjects = new List<PoolObject>();
    public bool AutoGeneration = false;
    private bool canProduce = true;

    #region AUTO GENERATION
    void Start()
    {
        if (AutoGeneration)
        {
            poolObjects = GenerateObjects(minObjectCount);
        }
    }
    #endregion
    private List<PoolObject> GenerateObjects(int amountOfObjects)
    {
        for (int i = 0; i < amountOfObjects; i++)
        {
            PoolObject obj = Instantiate(objectPrefab);
            obj.transform.parent = poolContainer.transform;
            obj.gameObject.SetActive(false);
            poolObjects.Add(obj);
        }
        return poolObjects;
    }

    public PoolObject RequestObj(Vector3 pos, Quaternion rot)
    {
        foreach (var obj in poolObjects)
        {
            if (obj.gameObject.activeInHierarchy == false)
            {
                obj.transform.position = pos;
                obj.transform.rotation = rot;
                obj.Activate();
                return obj;
            }
        }
        if (LookActives())
        {
            PoolObject newObj = Instantiate(objectPrefab);
            newObj.transform.parent = poolContainer.transform;
            poolObjects.Add(newObj);

            return newObj;
        }
        return null;
    }
    public bool LookActives()
    {
        int helperNum = 0;
        foreach (var obj in poolObjects)
        {
            if (obj.gameObject.activeInHierarchy == true)
            {
                helperNum++;
            }
        }
        if (helperNum < maxObjectCount)
        {
            canProduce = true;
            return canProduce;
        }
        else
        {
            canProduce = false;
            return canProduce;
        }
    }
    public void DismissAllObjs()
    {
        if (poolContainer.childCount > 0)
        {
            foreach (PoolObject obj in poolContainer.transform)
            {
                obj.Dismiss();
            }
        }

    }
}