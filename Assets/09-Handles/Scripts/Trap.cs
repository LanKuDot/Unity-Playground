using UnityEngine;

namespace PlayGround_09
{
    public class Trap : MonoBehaviour
    {
        public enum ShowingColor
        {
            X,
            Y,
            Z,
            Selected
        }

        [SerializeField]
        private float _detectionDistance = 2;
        [SerializeField]
        private bool _showSolidDisc;
        [SerializeField]
        private ShowingColor _color;

#if UNITY_EDITOR
        public float DetectionDistance
        {
            get => _detectionDistance;
            set => _detectionDistance = value;
        }

        public bool ShowSolidDisc => _showSolidDisc;
        public ShowingColor Color => _color;
#endif
    }
}
