using System;
using PlayGround_05;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayGround_06
{
    public class Player : Character
    {
        [SerializeField]
        private float _movingVelocity;
        [SerializeField]
        private GameObject _bulletPrefab;

        private Vector3 _movingDirection;
        private float _lookingDeg;

        public void OnMove(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _movingDirection = new Vector3(value.x, 0, value.y).normalized;
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            var playerScreenPos =
                (Vector2) Camera.main.WorldToScreenPoint(transform.position);
            _lookingDeg = -Vector2.SignedAngle(Vector2.up, value - playerScreenPos);
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            Fire(_bulletPrefab, transform.forward);
        }

        private void FixedUpdate()
        {
            Move(_movingVelocity * Time.deltaTime * _movingDirection);
            Look(_lookingDeg - transform.eulerAngles.y);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
                Debug.Log("Hit by the enemy");
        }
    }
}
