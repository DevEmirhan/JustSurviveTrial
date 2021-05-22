using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeGames.Actions
{
    public enum ShakeFunction
    {
        Sinus,
    }

    public class Shaker : MonoBehaviour
    {
        public bool LoadOnStart;
        public bool SakeOnStart;
        public ShakeFunction Function;
        public bool IsShaking;
        public bool IsLerped;
        public float LerpSpeed;
        public float Amount = 1;
        public Vector3 Axis = new Vector3(1, 1, 1);

        private Vector3 defPos, shakePos;
        private bool isReady;
        private float time;

        private void Start()
        {
            if (LoadOnStart)
            {
                Init();
            }
        }

        public void Init()
        {
            defPos = transform.localPosition;
            IsShaking = SakeOnStart;
            isReady = true;
        }

        public void Shake()
        {
            IsShaking = true;
        }

        public void StopShake()
        {
            IsShaking = false;
            transform.localPosition = defPos;
        }

        void Update()
        {
            if (IsShaking && isReady)
            {
                time += Time.deltaTime;
                time %= Mathf.PI;

                switch (Function)
                {
                    case ShakeFunction.Sinus:
                        shakePos.x = Axis.x * Random.Range(0f, Mathf.Sin(time)) * Amount;
                        shakePos.y = Axis.y * Random.Range(0f, Mathf.Sin(time)) * Amount;
                        shakePos.z = Axis.z * Random.Range(0f, Mathf.Sin(time)) * Amount;
                        break;
                    default:
                        break;
                }

                if (IsLerped)
                {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, defPos + shakePos, LerpSpeed * Time.deltaTime);
                }
                else
                {
                    transform.localPosition = defPos + shakePos;
                }
            }
        }
    }
}
