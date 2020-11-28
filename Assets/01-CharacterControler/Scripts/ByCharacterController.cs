using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ByCharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private float _speed = 8;

    private Vector3 _direction;

    private void Reset()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        _direction = new Vector3(value.x, 0, value.y);
    }

    private void FixedUpdate()
    {
        _characterController.SimpleMove(_speed * _direction);
        // or
        // _characterController.Move(_speed * Time.deltaTime * _direction);
    }
}
