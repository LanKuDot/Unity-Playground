using System;
using UnityEngine;

namespace PlayGround_07
{
    public class RotateEnemy : Enemy
    {
        [SerializeField]
        private RotateEnemyData _data;

        private void Awake()
        {
            enemyData = _data;
        }

        private void FixedUpdate()
        {
            Look(_data.rotatingVelocity * Time.deltaTime);
        }
    }
}
