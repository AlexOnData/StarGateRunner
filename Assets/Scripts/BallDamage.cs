using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [Header("Behaviour")]
    public bool destroyOnImpact = false;

    void OnCollisionEnter(Collision collision)
    {
        DealDamage(collision.collider);
    }

    void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }

    void DealDamage(Collider other)
    {
        if (other == null || !other.CompareTag("Player")) return;

        var ph = other.GetComponent<PlayerHealth>();
        if (ph == null) ph = other.GetComponentInParent<PlayerHealth>();
        if (ph == null) return;

        ph.TakeDamage();

        if (destroyOnImpact)
        {
            Destroy(gameObject);
        }
    }
}
