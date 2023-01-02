using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] bool destroyOnSpawn;

    Vector3 targetPosition = Vector3.zero;

    void Update()
    {
        UpdateTargetPostion();
        UpdatePosition();

        if (Input.GetMouseButtonUp(0))
            Spawn();
    }

    private void UpdateTargetPostion()
    {
        if (PhysicsExtension.Raycast(out Vector3 point))
            targetPosition = point;
    }

    void UpdatePosition()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    void Spawn()
    {
        Instantiate(spawnPrefab, transform.position, transform.rotation);

        if (destroyOnSpawn)
            DestroyImmediate(gameObject);
    }
}
