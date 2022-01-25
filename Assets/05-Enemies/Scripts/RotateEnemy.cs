using UnityEngine;

namespace PlayGround_05
{
    public class RotateEnemy : Enemy
    {
        [SerializeField]
        private float _rotatingVelocity;

        private void FixedUpdate()
        {
            Look(_rotatingVelocity * Time.deltaTime);
        }
    }
}
