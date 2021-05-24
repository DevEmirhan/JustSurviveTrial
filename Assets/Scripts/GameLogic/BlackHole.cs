using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlackHole : Enemy
{
    [SerializeField] private NavMeshAgent holeNavMesh;
    [SerializeField] private float directSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float waitSecondsNextMove;

    [SerializeField] private bool isHaveAPath;
    [SerializeField]
    private List<Transform> path = new List<Transform>();
    private Transform currentDestination;
    private bool readyForNextPos;
 

    public override void ActivateEnemy()
    {
        base.ActivateEnemy();
        holeNavMesh.speed = directSpeed;
        holeNavMesh.angularSpeed = turnSpeed;
        if (isHaveAPath)
            StartCoroutine(WaitForNextMovement());
    }

    public override void DeactivateEnemy()
    {
        holeNavMesh.isStopped = true;
        base.DeactivateEnemy();
    }

    private void Update()
    {
        if (isActivated)
        {
            if (holeNavMesh.remainingDistance < 0.2f && !readyForNextPos && isHaveAPath)
            {
                StartCoroutine(WaitForNextMovement());
            }
        }
    }
    private IEnumerator WaitForNextMovement()
    {
        StopHole();
        yield return new WaitForSeconds(waitSecondsNextMove);
        if (isActivated)
        {       
            SetNewDestination();
        }
    }
    private void StopHole()
    {
        holeNavMesh.isStopped = true;
        readyForNextPos = true;
    }
    private void SetNewDestination()
    {
        int randomIndex = Random.Range(0, path.Count);
        currentDestination = path[randomIndex];
        holeNavMesh.SetDestination(currentDestination.position);
        holeNavMesh.isStopped = false;
        readyForNextPos = false;
    }
    public void PlayerCatched()
    {
        DeactivateEnemy();
    }
}
