using System.Collections;
using UnityEngine;

namespace PlayGround_04
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float _lifeTime = 3;

        private Renderer _renderer;
        private MaterialPropertyBlock _materialPropertyBlock;
        private readonly int _colorProp = Shader.PropertyToID("_Color");

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _materialPropertyBlock = new MaterialPropertyBlock();
        }

        private void OnEnable()
        {
            RandomColor();
            StartCoroutine(LifeTimeCountDown());
        }

        private void RandomColor()
        {
            var color = Random.ColorHSV();
            _materialPropertyBlock.SetColor(_colorProp, color);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }

        private IEnumerator LifeTimeCountDown()
        {
            yield return new WaitForSeconds(_lifeTime);
            ObjectPool.Instance.ReturnObject(gameObject);
        }
    }
}
