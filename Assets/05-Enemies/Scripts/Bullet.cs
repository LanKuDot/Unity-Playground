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

        public void Fire(Vector3 direction)
        {
            transform.forward = direction;
            _movingDirection = direction;
            StartCoroutine(LiveTimeCountdown());
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
