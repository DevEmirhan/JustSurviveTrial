using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected float waitBeforeActivationTime = 3f;
    [SerializeField] protected float activationTime = 1f;

    protected bool isActivated = false;

    public virtual void ActivateTrap()
    {
        isActivated = true;
    }
    public virtual void DeactivateTrap()
    {
        isActivated = false;
    }
}