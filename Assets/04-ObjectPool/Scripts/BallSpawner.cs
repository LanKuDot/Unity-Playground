using UnityEngine;

namespace PlayGround_04
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _relativeSpawnRange;
        [SerializeField]
        private GameObject _ballPrefab;

        public void Spawn()
        {
            var ball = ObjectPool.Instance.GetObject(_ballPrefab.name);
            ball.transform.SetParent(null);
            ball.transform.position =
                transform.position +
                new Vector3(
                    Random.Range(-_relativeSpawnRange.x, _relativeSpawnRange.x),
                    Random.Range(-_relativeSpawnRange.y, _relativeSpawnRange.y),
                    Random.Range(-_relativeSpawnRange.z, _relativeSpawnRange.z));
            ball.SetActive(true);
        }
    }
}
