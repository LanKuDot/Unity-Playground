using System;
using System.Collections;
using UnityEngine;

namespace PlayGround_05
{
    /// <summary>
    /// The base class of the enemy
    /// </summary>
    public class Enemy : Character
    {
        [SerializeField]
        private FireAction[] _fireActions;
        [SerializeField]
        private float _fireInterval;

        private bool _isFiring;

        protected void Start()
        {
            if (_fireActions.Length == 0)
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
                foreach (var action in _fireActions) {
                    Fire(
                        action.bulletPrefab,
                        Quaternion.AngleAxis(action.degree, Vector3.up) * forward);
                }
                yield return new WaitForSeconds(_fireInterval);
            }
        }
    }

    /// <summary>
    /// The action for firing a bullet
    /// </summary>
    [Serializable]
    public class FireAction
    {
        [SerializeField]
        private GameObject _bulletPrefab;
        [SerializeField]
        private float _degree;

        public GameObject bulletPrefab => _bulletPrefab;
        public float degree => _degree;
    }
}
