using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayGround_04
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

        [SerializeField]
        private ObjectPoolItem[] _objectPoolItems;

        /// <summary>
        /// The dictionary that mapping the object name to the pool item
        /// </summary>
        private readonly Dictionary<string, ObjectPoolItem> _objectPoolItemsDict =
            new Dictionary<string, ObjectPoolItem>();
        /// <summary>
        /// The dictionary that storing the objects for each pool item
        /// </summary>
        private readonly Dictionary<string, Queue<GameObject>> _objectPool =
            new Dictionary<string, Queue<GameObject>>();

        private void Awake()
        {
            Instance = this;
            InitializePool();
        }

        /// <summary>
        /// Initialize the object pool
        /// </summary>
        private void InitializePool()
        {
            foreach (var item in _objectPoolItems) {
                Debug.Assert(
                    item.prefab,
                    $"{name}: There has unassigned prefab in the pool items");

                var itemName = item.name;
                var queue = new Queue<GameObject>();

                _objectPoolItemsDict[itemName] = item;
                _objectPool[itemName] = queue;

                for (var i = 0; i < item.initialNum; ++i) {
                    var obj = SpawnObject(itemName);
                    obj.transform.SetParent(transform);
                    obj.SetActive(false);
                    queue.Enqueue(obj);
                }
            }
        }

        /// <summary>
        /// Spawn a new object from the specified pool item
        /// </summary>
        /// <param name="poolItemName">The name of the pool item</param>
        /// <returns>The spawned game object</returns>
        private GameObject SpawnObject(string poolItemName)
        {
            var prefab = _objectPoolItemsDict[poolItemName].prefab;
            var obj = Instantiate(prefab);
            obj.name = poolItemName;
            return obj;
        }

        /// <summary>
        /// Get the specified object from the pool
        /// </summary>
        /// <param name="poolItemName">The name of the pool item</param>
        /// <returns></returns>
        public GameObject GetObject(string poolItemName)
        {
            var objQueue = _objectPool[poolItemName];
            return objQueue.Count > 0 ?
                objQueue.Dequeue() :
                SpawnObject(poolItemName);
        }

        /// <summary>
        /// Return object to the pool
        /// </summary>
        /// The name of the object will be used for searching pool item
        /// <param name="obj">The object to be returned</param>
        public void ReturnObject(GameObject obj)
        {
            obj.transform.SetParent(transform);
            if (obj.activeSelf)
                obj.SetActive(false);

            _objectPool[obj.name].Enqueue(obj);
        }
    }

    [Serializable]
    public class ObjectPoolItem
    {
        [SerializeField, HideInInspector]
        [Tooltip("The name of the pool item")]
        private string _name;
        [SerializeField]
        [Tooltip("The prefab for spawning objects in the pool")]
        private GameObject _prefab;
        [SerializeField, Min(0)]
        [Tooltip("The initial number of objects in the pool")]
        private int _initialNum;

        public string name => _name;
        public GameObject prefab => _prefab;
        public int initialNum => _initialNum;
    }
}
