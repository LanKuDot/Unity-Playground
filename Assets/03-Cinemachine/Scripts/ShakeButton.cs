using System.Collections;
using Cinemachine;
using UnityEngine;

public class ShakeButton : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _shakeVirtualCamera;
    [SerializeField]
    private float _amplitudeGain = 1f;
    [SerializeField]
    private float _frequencyGain = 15f;
    [SerializeField]
    private float _shakeInterval = 0.2f;

    private CinemachineBasicMultiChannelPerlin _cameraPerlin;

    private void Awake()
    {
        _cameraPerlin =
            _shakeVirtualCamera
                .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }

    private IEnumerator ShakeCameraCoroutine()
    {
        _cameraPerlin.m_AmplitudeGain = _amplitudeGain;
        _cameraPerlin.m_FrequencyGain = _frequencyGain;
        yield return new WaitForSeconds(_shakeInterval);
        _cameraPerlin.m_AmplitudeGain = 0;
        _cameraPerlin.m_FrequencyGain = 0;
    }
}
