﻿using UnityEngine;

namespace PlayGround_05
{
    public class ChaseEnemy : Enemy
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private float _movingVelocity;
        [SerializeField]
        private float _rotatingVelocity;

        private void FixedUpdate()
        {
            Move(_movingVelocity * Time.deltaTime * GetMovingVector());

            var deltaDegree = GetRotationDegree();
            var maxDegree = _rotatingVelocity * Time.deltaTime;
            deltaDegree =
                Mathf.Min(Mathf.Abs(deltaDegree), maxDegree)
                * Mathf.Sign(deltaDegree);
            Look(deltaDegree);
        }

        /// <summary>
        /// Get the moving vector towards the target
        /// </summary>
        private Vector3 GetMovingVector()
        {
            var targetVector = _target.position - transform.position;
            targetVector.y = 0;
            return targetVector.normalized;
        }

        /// <summary>
        /// Get the delta degree to rotate to face the target
        /// </summary>
        private float GetRotationDegree()
        {
            var curFacing = transform.forward;
            var targetFacing = _target.position - transform.position;
            targetFacing.y = 0;
            return Vector3.SignedAngle(curFacing, targetFacing, Vector3.up);
        }
    }
}
