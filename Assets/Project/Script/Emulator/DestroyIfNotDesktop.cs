using UnityEngine;

public class DestroyIfNotDesktop : MonoBehaviour
{
    void Awake()
    {
        if (SystemInfo.deviceType != DeviceType.Desktop)
            DestroyImmediate(gameObject);
    }
}

