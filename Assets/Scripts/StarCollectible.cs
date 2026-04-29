using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StarCollectible : MonoBehaviour
{
    [Header("Optional")]
    public AudioClip collectClip;
    public float rotationSpeed = 90f;

    bool collected = false;

    void Reset()
    {
        // Auto-set trigger when component is added in editor.
        var col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    void Update()
    {
        if (collected) return;
        if (rotationSpeed != 0f)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        collected = true;

        if (GameManager.Instance != null) GameManager.Instance.AddStar();

        // PlayClipAtPoint creates a temporary AudioSource so the sound survives Destroy.
        if (collectClip != null)
        {
            AudioSource.PlayClipAtPoint(collectClip, transform.position);
        }

        Destroy(gameObject);
    }
}
