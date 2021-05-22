using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PoolManager : Singleton<PoolManager>
{
    public List<ObjectPool> Pools = new List<ObjectPool>();
   
    public ObjectPool GetPoolWithIndex(int i)
    {
        return Pools[i];
    }
    public void DismissPoolWithIndex(int i)
    {
        Pools[i].DismissAllObjs();
    }
    public void DismissPools()
    {
        foreach (ObjectPool pool in Pools)
        {
            pool.DismissAllObjs();
        }
    }
}
