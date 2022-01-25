using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace PlayGround_02
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _cursorTransform = null;
        [SerializeField]
        private Text _bindingText = null;
        [SerializeField]
        private Text _valueText = null;
        [SerializeField]
        private float _movingRange = 50f;

        public void OnMove(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _cursorTransform.anchoredPosition = value * _movingRange;

            _bindingText.text = $"Binding: {context.control.path}";
            _valueText.text = $"Value: {value}";
        }
    }
}
