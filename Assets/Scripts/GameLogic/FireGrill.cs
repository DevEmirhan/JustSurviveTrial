using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrill : Trap
{
    [SerializeField] private Collider fireCol;
    [SerializeField] private GameObject fireVFX;

    private float repeatTime = 0f;
    private float additionalRandomTime;

    public override void ActivateTrap()
    {
        base.ActivateTrap();
        additionalRandomTime = Random.Range(0.1f, 0.4f);
        repeatTime = waitBeforeActivationTime + additionalRandomTime;
        StartCoroutine(ThrowFire());
    }
    public override void DeactivateTrap()
    {
        StopCoroutine(ThrowFire());
        base.DeactivateTrap();
    }

    IEnumerator ThrowFire()
    {
        while (isActivated)
        {
            yield return new WaitForSeconds(repeatTime);
            fireVFX.SetActive(true);
            fireCol.enabled = true;
            yield return new WaitForSeconds(activationTime);
            fireVFX.SetActive(false);
            fireCol.enabled = false;
        }
    }
}
