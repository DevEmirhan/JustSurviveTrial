using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeGames.Actions
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1, amount = 0.02f;
        [SerializeField]
        private float limitAmont = 0.15f;
        [SerializeField]
        private Vector3 dimension = new Vector3(1, 1, 1);

        private Vector3 scale = Vector3.one;
        private Vector3 baseScale = Vector3.one;

        private bool isUp = false;

        [SerializeField]
        private bool destroyAfter = false;

        [SerializeField]
        float destroyTime, dTimer;

        private void Start()
        {
            scale = transform.localScale;
            baseScale = transform.localScale;
        }

        private void OnEnable()
        {
            dTimer = 0;
        }

        private void FixedUpdate()
        {
            if (!isUp)
            {
                scale += dimension * amount * speed;

                if (scale.x > baseScale.x + limitAmont)
                {
                    isUp = true;
                }
            }
            else
            {
                scale -= dimension * amount * speed;

                if (scale.x < baseScale.x - limitAmont)
                {
                    isUp = false;
                }
            }

            transform.localScale = scale;

            if (destroyAfter)
            {
                dTimer += Time.deltaTime;
                if (dTimer > destroyTime)
                {
                    dTimer = 0;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
