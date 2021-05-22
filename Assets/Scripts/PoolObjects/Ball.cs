using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : PoolObject
{
    [SerializeField]
    private Rigidbody ballRb;
    [SerializeField]
    private float ballDisappearTime = 3f;

    public override void Dismiss()
    {
        isActive = false;
        ballRb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    public void Shoot(Vector3 dir, float pow)
    {
        ballRb.AddForce(transform.forward * pow);
        Invoke("Dismiss", ballDisappearTime);
        
    }
}
