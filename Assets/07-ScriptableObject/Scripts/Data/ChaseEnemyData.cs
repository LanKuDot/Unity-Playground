using UnityEngine;

namespace PlayGround_07
{
    [CreateAssetMenu(
        fileName = "ChaseEnemyData",
        menuName = "Data/Chase Enemy")]
    public class ChaseEnemyData : EnemyData
    {
        [SerializeField]
        private float _movingVelocity;
        [SerializeField]
        private float _rotatingVelocity;

        public float movingVelocity => _movingVelocity;
        public float rotatingVelocity => _rotatingVelocity;

#if UNITY_EDITOR
        public string GetSimpleSceneDisplayInfo()
        {
            return name;
        }

        public string GetSceneDisplayInfo()
        {
            return $"{name}\n"
                   + $"Moving Velocity: {_movingVelocity}\n"
                   + $"Rotating Velocity: {_rotatingVelocity}";
        }
#endif
    }
}
