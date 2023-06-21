using UnityEngine;

namespace PlayGround_08
{
    [RequireComponent(typeof(BoxCollider))]
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider _trigger;
        [SerializeField]
        private GameObject[] _objectsToBeActivated;

#if UNITY_EDITOR
        public BoxCollider Trigger => _trigger;
#endif

        private void Reset()
        {
            if (TryGetComponent(out _trigger))
                _trigger.isTrigger = true;
        }

        private void Start()
        {
            foreach (var obj in _objectsToBeActivated) {
                obj.SetActive(false);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            var triggerTransform = transform;
            var triggerForward = triggerTransform.forward;
            var otherVector = other.transform.position - triggerTransform.position;

            if (Vector3.Dot(triggerForward, otherVector) <= 0)
                return;

            foreach (var obj in _objectsToBeActivated) {
                obj.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
