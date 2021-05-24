using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool isActivated = false;
    // Start is called before the first frame update
    public virtual void ActivateEnemy()
    {
        isActivated = true;
    }
    public virtual void DeactivateEnemy()
    {
        isActivated = false;
    }
}
