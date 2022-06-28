using UnityEngine;

namespace PlayGround_07
{
    [CreateAssetMenu(
        fileName = "PathEnemyData",
        menuName = "Data/Path Enemy")]
    public class PathEnemyData : EnemyData
    {
        [SerializeField]
        private float _movingVelocity;

        public float movingVelocity => _movingVelocity;
    }
}
