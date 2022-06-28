using System;
using UnityEngine;

namespace PlayGround_07
{
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        private FireAction[] _fireActions;
        [SerializeField]
        private float _fireInterval;

        public FireAction[] fireActions => _fireActions;
        public float fireInterval => _fireInterval;
    }

    /// <summary>
    /// The action for firing a bullet
    /// </summary>
    [Serializable]
    public class FireAction
    {
        [SerializeField]
        private GameObject _bulletPrefab;
        [SerializeField]
        private float _degree;

        public GameObject bulletPrefab => _bulletPrefab;
        public float degree => _degree;
    }
}
