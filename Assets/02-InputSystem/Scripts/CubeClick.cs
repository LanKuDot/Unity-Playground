using UnityEngine;

namespace PlayGround_02
{
    public class CubeClick : MonoBehaviour
    {
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;
        }

        // This function won't be invoked if the value of "Active Input Handling"
        // in the Player Settings is not "Both" when Input System is activated.
        private void OnMouseDown()
        {
            _material.color = Random.ColorHSV();
        }
    }
}
