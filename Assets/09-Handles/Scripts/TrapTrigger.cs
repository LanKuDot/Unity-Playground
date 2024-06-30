using UnityEngine;

namespace PlayGround_09
{
    public class TrapTrigger : MonoBehaviour
    {
        [SerializeField]
        private Trap _trap;

#if UNITY_EDITOR
        public Trap Trap => _trap;
#endif
    }
}
