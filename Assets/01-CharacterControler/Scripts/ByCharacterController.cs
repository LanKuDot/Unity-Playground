using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayGround_01
{
    [RequireComponent(typeof(CharacterController))]
    public class ByCharacterController : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private float _speed = 8;

        private Vector3 _direction;
        private Func<Vector2, float> _lookAction;
        private float _lookingDeg;

        private void Reset()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Awake()
        {
            _lookAction = LookAtPointer;
        }

        public void OnInputDeviceChanged(PlayerInput input)
        {
            if (input.currentControlScheme.Equals("Gamepad"))
                _lookAction = LookByStick;
            else
                _lookAction = LookAtPointer;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _direction = new Vector3(value.x, 0, value.y);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            _lookingDeg = _lookAction(context.ReadValue<Vector2>());
        }

        private float LookAtPointer(Vector2 pointerPos)
        {
            var playerScreenPos =
                (Vector2) Camera.main.WorldToScreenPoint(transform.position);

            return -Vector2.SignedAngle(Vector2.up, pointerPos - playerScreenPos);
        }

        private float LookByStick(Vector2 direction)
        {
            if (direction.magnitude < 0.1)
                return _lookingDeg;

            return -Vector2.SignedAngle(Vector2.up, direction);
        }

        private void FixedUpdate()
        {
            _characterController.SimpleMove(_speed * _direction);
            // or
            // _characterController.Move(_speed * Time.deltaTime * _direction);

            transform.rotation = Quaternion.Euler(0, _lookingDeg, 0);
        }
    }
}
