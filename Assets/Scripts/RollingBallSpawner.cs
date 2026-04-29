using System.Collections;
using UnityEngine;

public class RollingBallSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject ballPrefab;

    [Header("Spawn")]
    public Transform spawnPoint;
    public float spawnInterval = 5f;
    public float ballLifetime = 10f;
    public float startDelay = 1f;

    [Header("Optional")]
    public Vector3 initialVelocity = Vector3.zero;
    public Transform ballParent;

    void Start()
    {
        if (spawnPoint == null) spawnPoint = transform;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        if (startDelay > 0f) yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBall()
    {
        if (ballPrefab == null)
        {
            Debug.LogWarning("[RollingBallSpawner] ballPrefab is not assigned.");
            return;
        }

        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation, ballParent);

        if (initialVelocity != Vector3.zero)
        {
            var rb = ball.GetComponent<Rigidbody>();
            if (rb != null) rb.linearVelocity = initialVelocity;
        }

        Destroy(ball, ballLifetime);
    }
}
