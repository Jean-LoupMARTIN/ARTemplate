using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public static class PhysicsExtension
{
    static ARRaycastManager ARRaycastManager => ARRaycastManagerCached ??= GameObject.FindObjectOfType<ARRaycastManager>();
    static ARRaycastManager ARRaycastManagerCached;


    static public bool ARRaycast(out Vector3 point)
    {
        Vector3 screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (ARRaycastManager.Raycast(screenCenter, hits, TrackableType.All))
        {
            point = hits[0].pose.position;
            return true;
        }

        point = Vector3.zero;
        return false;
    }

    static public bool MouseRaycast(out Vector3 point, LayerMask layer)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer))
        {
            point = hit.point;
            return true;
        }

        point = Vector3.zero;
        return false;
    }

    static public bool Raycast(out Vector3 point)
    {
        return SystemInfo.deviceType == DeviceType.Desktop ? MouseRaycast(out point, LayerMask.GetMask("FakeEnv")) : ARRaycast(out point); ;
    }
}
