using System.Collections;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float rotSpeed = 10;


    void Awake()
    {
        if (SystemInfo.deviceType != DeviceType.Desktop)
            Destroy(this);
    }

    void Start()
    {
        StartCoroutine(CheckRotate());
    }

    void Update()
    {
        Translate();
    }


    void Translate()
    {
        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * speed * Time.deltaTime);
    }


    IEnumerator CheckRotate()
    {
        while (!Input.GetMouseButton(1))
            yield return new WaitForEndOfFrame();

        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        Vector2 lastPos = Input.mousePosition, newPos, dPos;

        while (Input.GetMouseButton(1))
        {
            newPos = Input.mousePosition;
            dPos = newPos - lastPos;
            lastPos = newPos;

            transform.Rotate(-dPos.y * rotSpeed, 0, 0);
            transform.RotateAround(transform.position, Vector3.up, dPos.x * rotSpeed);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(CheckRotate());
    }
}
