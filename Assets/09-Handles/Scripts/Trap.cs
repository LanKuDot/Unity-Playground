using UnityEngine;

namespace PlayGround_09
{
    public class Trap : MonoBehaviour
    {
        [SerializeField]
        private float _detectionDistance = 2;

#if UNITY_EDITOR
        public float DetectionDistance
        {
            get => _detectionDistance;
            set => _detectionDistance = value;
        }
#endif
    }
}
