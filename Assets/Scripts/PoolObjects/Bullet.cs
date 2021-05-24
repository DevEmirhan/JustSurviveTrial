using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{
    [SerializeField]
    private GameObject bulletModel;
    [SerializeField]
    private ParticleSystem bulletExpo;
    [SerializeField]
    private SphereCollider bulletCol;
    [SerializeField]
    private float fireSpeed = 10f;
    [SerializeField]
    private float expoRange = 5f;
    private Vector3 currentTarget;

    public void ShootBullet(Transform targetPos)
    {
        bulletCol.radius = expoRange;
        currentTarget = targetPos.transform.position;
        bulletModel.SetActive(true);
        StartCoroutine(SimulateProjectile());
    }
    public IEnumerator SimulateProjectile()
    {
        yield return new WaitForSeconds(0.2f);
        float target_Distance = Vector3.Distance(transform.position, currentTarget);

        transform.rotation = Quaternion.LookRotation(currentTarget - transform.position);

        while (Vector3.Distance(transform.position, currentTarget) > 0.1)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * fireSpeed);
            yield return null;
        }
        bulletModel.SetActive(false);
        bulletExpo.Play();
        yield return new WaitForSeconds(bulletExpo.main.duration);

        gameObject.SetActive(false);

    }
}
