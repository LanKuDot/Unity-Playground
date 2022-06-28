using System;
using System.Collections;
using PlayGround_05;
using UnityEngine;

namespace PlayGround_07
{
    public class Enemy : Character
    {
        protected EnemyData enemyData { get; set; }

        private bool _isFiring;

        protected void Start()
        {
            if (enemyData.fireActions.Length == 0)
                return;

            _isFiring = true;
            StartCoroutine(FireCoroutine());
        }

        protected void OnDisable()
        {
            _isFiring = false;
        }

        protected void OnTriggerEnter(Collider other)
        {
            // Added in PlayGround_06
            if (other.CompareTag("Bullet"))
                Debug.Log("Hit by the player");
        }

        /// <summary>
        /// The coroutine for controlling the firing actions
        /// </summary>
        private IEnumerator FireCoroutine()
        {
            while (_isFiring) {
                var forward = transform.forward;
                foreach (var action in enemyData.fireActions) {
                    Fire(
                        action.bulletPrefab,
                        Quaternion.AngleAxis(action.degree, Vector3.up) * forward);
                }
                yield return new WaitForSeconds(enemyData.fireInterval);
            }
        }
    }
}
