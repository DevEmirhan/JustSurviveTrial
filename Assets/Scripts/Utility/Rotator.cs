using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeGames.Actions
{
    public class Rotator : MonoBehaviour
    {
        public float RotSpeed = 1;
        public Vector3 Axis = new Vector3(0, 0, 1);

        void Update()
        {
            transform.Rotate(Axis, RotSpeed * Time.deltaTime);
        }
    }
}
