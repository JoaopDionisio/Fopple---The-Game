using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;

    private Vector3 originalPosition;

    public void Shake()
    {
        originalPosition = transform.position;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", shakeDuration);
    }

    private void DoShake()
    {
        float offsetX = Random.Range(-shakeAmount, shakeAmount);
        float offsetY = Random.Range(-shakeAmount, shakeAmount);
        Vector3 pos = transform.position;
        pos.x += offsetX;
        pos.y += offsetY;
        transform.position = pos;
    }

    private void StopShake()
    {
        CancelInvoke("DoShake");
        transform.position = originalPosition;
    }
}