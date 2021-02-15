using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonTimingTest : MonoBehaviour
{
    [SerializeField]
    private Text _startedTimingText;
    [SerializeField]
    private Text _performedTimingText;
    [SerializeField]
    private Text _canceledTimingText;

    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase) {
            case InputActionPhase.Started:
                _startedTimingText.text = $"Started: {context.startTime:F2}";
                _performedTimingText.text = "Performed: -";
                _canceledTimingText.text = "Canceled: -";
                break;
            case InputActionPhase.Performed:
                _performedTimingText.text =
                    $"Performed: +{(float)context.duration:F2}";
                break;
            case InputActionPhase.Canceled:
                _canceledTimingText.text =
                    $"Canceled: +{(float)context.duration:F2}";
                break;
        }
    }
}
