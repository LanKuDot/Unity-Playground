using UnityEngine;

namespace PlayGround_09
{
    [RequireComponent(typeof(CharacterController))]
    public class PathEnemy : MonoBehaviour
    {
        [SerializeField]
        private Path _path;
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private float _movingVelocity;

        private void Reset()
        {
            TryGetComponent(out _characterController);
        }

        private void Start()
        {
            transform.position = _path.GetNextPosition(0);
        }

        private void FixedUpdate()
        {
            var curPosition = transform.position;
            var nextPosition = _path.GetNextPosition(_movingVelocity * Time.deltaTime);
            _characterController.Move(nextPosition - curPosition);
        }
    }
}
