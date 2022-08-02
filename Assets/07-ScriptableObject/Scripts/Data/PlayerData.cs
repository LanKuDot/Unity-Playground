using UnityEngine;

namespace PlayGround_07
{
    //[CreateAssetMenu(
    //    fileName = "PlayerData",
    //    menuName = "Data/Player/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private float _movingVelocity;
        [SerializeField]
        private float _rotateVelocity;
        [SerializeField]
        private float _fireInterval;

        public float movingVelocity => _movingVelocity;
        public float rotateVelocity => _rotateVelocity;
        public float fireInterval => _fireInterval;
    }
}
