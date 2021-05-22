using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    protected bool isActive = false;

    public virtual void Activate()
    {
        gameObject.SetActive(true);
        isActive = true;
    }
    public virtual void ActivateWithPosition(Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
        gameObject.SetActive(true);
        isActive = true;
    }


    public virtual void Dismiss()
    {
        isActive = false;
        gameObject.SetActive(false);
    }
    
}
