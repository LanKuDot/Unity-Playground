using UnityEngine;

namespace PlayGround_07
{
    [CreateAssetMenu(
        fileName = "RotateEnemyData",
        menuName = "Data/Rotate Enemy")]
    public class RotateEnemyData : EnemyData
    {
        [SerializeField]
        private float _rotatingVelocity;

        public float rotatingVelocity => _rotatingVelocity;
    }
}
