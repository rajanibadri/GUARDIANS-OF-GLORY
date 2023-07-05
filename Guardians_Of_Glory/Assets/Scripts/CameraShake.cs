using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.2f;
    public float shakeDuration = 0.5f;
    
    private float shakeTimer = 0f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    
    void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
       
    }
    
    public void TriggerCameraShake()
    {
        shakeTimer = shakeDuration;
    }
    
    void Update()
    {
        if (shakeTimer > 0f)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
            Quaternion shakeRotation = Quaternion.Euler(shakeOffset.x, shakeOffset.y, shakeOffset.z);
            
            transform.localPosition = originalPosition + shakeOffset;
            transform.localRotation = originalRotation * shakeRotation;
            
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
        }
    }
}
