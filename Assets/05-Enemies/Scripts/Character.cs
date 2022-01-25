using PlayGround_04;
using UnityEngine;

namespace PlayGround_05
{
    /// <summary>
    /// The base class of the character
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        protected void Reset()
        {
            _characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Move the character for the specified delta position
        /// </summary>
        protected void Move(Vector3 deltaPos)
        {
            _characterController.Move(deltaPos);
        }

        /// <summary>
        /// Rotate the character for the delta degrees
        /// </summary>
        protected void Look(float deltaDeg)
        {
            transform.rotation *= Quaternion.AngleAxis(deltaDeg, Vector3.up);
        }

        /// <summary>
        /// Fire a bullet along the direction in the world space
        /// </summary>
        /// <param name="bulletPrefab">
        /// The prefab of the bullet, which is used to query the object from
        /// the object pool
        /// </param>
        /// <param name="direction">The direction in the world space</param>
        protected void Fire(GameObject bulletPrefab, Vector3 direction)
        {
            var bulletObject = ObjectPool.Instance.GetObject(bulletPrefab.name);
            var bulletTransform = bulletObject.transform;
            bulletTransform.SetParent(null);
            bulletTransform.position = transform.position + direction;
            bulletObject.SetActive(true);
            bulletObject.GetComponent<Bullet>().Fire(direction);
        }
    }
}
