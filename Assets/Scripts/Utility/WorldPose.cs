using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPose : MonoBehaviour
{
    [ExecuteInEditMode]
    [SerializeField] float radius = 0.5f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, radius);
    }
}
