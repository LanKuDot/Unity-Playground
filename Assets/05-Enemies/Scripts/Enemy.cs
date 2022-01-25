using System;
using System.Collections;
using UnityEngine;

namespace PlayGround_05
{
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
