using UnityEngine;
using UnityEngine.Rendering.Universal;


public class RemoveFakeEnvCamIfNotDesktop : MonoBehaviour
{
    void Awake()
    {
        if (SystemInfo.deviceType != DeviceType.Desktop)
            Combine();
    }

    void Combine()
    {
        Camera camera = GetComponent<Camera>();
        Camera.main.GetUniversalAdditionalCameraData().cameraStack.Remove(camera);
        Camera.main.cullingMask |= camera.cullingMask;
        DestroyImmediate(gameObject);
    }
}
