using System.Collections;
using PlayGround_04;
using UnityEngine;

namespace PlayGround_05
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _movingSpeed;
        [SerializeField]
        private float _liveTime;

        private Vector3 _movingDirection;

        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }

        /// <summary>
        /// Fire the bullet along the specified direction
        /// </summary>
        /// <param name="direction">The moving direction in the world space</param>
        public void Fire(Vector3 direction)
        {
            transform.forward = direction;
            _movingDirection = direction;
            StartCoroutine(LiveTimeCountdown());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Character")
                || other.CompareTag("Bullet"))
                ObjectPool.Instance.ReturnObject(gameObject);
        }

        private void FixedUpdate()
        {
            var nextPosition =
                _rigidbody.position
                + _movingSpeed * Time.deltaTime * _movingDirection;

            _rigidbody.MovePosition(nextPosition);
        }

        private IEnumerator LiveTimeCountdown()
        {
            yield return new WaitForSeconds(_liveTime);
            ObjectPool.Instance.ReturnObject(gameObject);
        }
    }
}
