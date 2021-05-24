using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    [SerializeField] private GameObject shooterHeadModel;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SphereCollider shootRangeCol;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float attackRate = 3f;
    [SerializeField] private ParticleSystem shootFireVFX;
    private Transform target;
    private Vector3 targetDir;
    private float attackTimer;

    public override void ActivateEnemy()
    {
        base.ActivateEnemy();
        attackTimer = 0f;
        shootRangeCol.radius = attackRange;
    }

    public override void DeactivateEnemy()
    {
        base.DeactivateEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if(target != null)
            {
                targetDir = target.position - transform.position;
                Quaternion toRotation = Quaternion.LookRotation(targetDir, Vector3.up);
                float eulerY = toRotation.eulerAngles.y;
                shooterHeadModel.transform.rotation = Quaternion.RotateTowards(shooterHeadModel.transform.rotation, toRotation, turnSpeed * Time.deltaTime);
                attackTimer += Time.deltaTime; 
                if(attackTimer > attackRate)
                {
                    Attack();
                    attackTimer = 0f;
                }
            } else
            {
                targetDir = Vector3.zero;
            }
        }
    }
    private void Attack()
    {
        Bullet bullet = PoolManager.Instance.GetPoolWithIndex(0).RequestObj(firePoint.position, firePoint.rotation)as Bullet;
        shootFireVFX.Play();
        bullet.ShootBullet(target);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
        attackTimer = 0f;
    }
}
