using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LavaDamage : MonoBehaviour
{
    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var ph = other.GetComponent<PlayerHealth>();
        if (ph == null) ph = other.GetComponentInParent<PlayerHealth>();
        if (ph == null) return;

        ph.TakeDamage();
    }
}
