using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap
{
    [SerializeField] private GameObject spikes;
    [SerializeField] private Collider spikeCol;
    [SerializeField] private Animator spikeAC;

    
    private float repeatTime = 0f;
    private float additionalRandomTime;

    public override void ActivateTrap()
    {
        base.ActivateTrap();
        additionalRandomTime = Random.Range(0.1f, 0.4f);
        repeatTime = waitBeforeActivationTime + additionalRandomTime;
        StartCoroutine(ThrowSpikes());
    }
    public override void DeactivateTrap()
    {
        base.DeactivateTrap();
    }

    IEnumerator ThrowSpikes()
    {
        while (isActivated)
        {
            yield return new WaitForSeconds(repeatTime);
            spikeAC.Play("SpikeOpen");
            yield return new WaitForSeconds(activationTime);
            spikeAC.Play("SpikeClose");
        }
    }
}
