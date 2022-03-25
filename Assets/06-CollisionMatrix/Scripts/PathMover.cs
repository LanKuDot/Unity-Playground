using UnityEngine;

namespace PlayGround_06
{
    [RequireComponent(typeof(Rigidbody))]
    public class PathMover : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private Transform[] _pathPoints;
        [SerializeField]
        private float _movingVelocity;

        private int _currentIndex;
        private Vector3 _movingVector;
        private float _timeRemain;

        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Awake()
        {
            SetNextPoint();
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"OnCollisionEnter: {other.gameObject.name}");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter: {other.gameObject.name}");
        }

        private void FixedUpdate()
        {
            if (_timeRemain < 0)
                SetNextPoint();

            var nextPosition =
                transform.position + _movingVelocity * Time.deltaTime * _movingVector;
            _rigidbody.MovePosition(nextPosition);

            _timeRemain -= Time.deltaTime;
        }

        private void SetNextPoint()
        {
            _currentIndex = (int) Mathf.Repeat(
                _currentIndex + 1, _pathPoints.Length);

            var deltaPosition =
                _pathPoints[_currentIndex].position - transform.position;
            deltaPosition.y = 0;

            _movingVector = deltaPosition.normalized;
            _timeRemain = deltaPosition.magnitude / _movingVelocity;
        }
    }
}
