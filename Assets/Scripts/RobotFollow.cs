using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RobotFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;
    public string playerTag = "Player";

    [Header("Damage")]
    public float damageCooldown = 1f;
    float lastDamageTime = -999f;

    [Header("Movement")]
    public float repathInterval = 0.2f;
    float lastPathTime = -999f;

    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        if (player == null)
        {
            var go = GameObject.FindGameObjectWithTag(playerTag);
            if (go != null) player = go.transform;
        }
    }

    void Update()
    {
        if (player == null || agent == null || !agent.isOnNavMesh) return;
        if (Time.time - lastPathTime < repathInterval) return;
        lastPathTime = Time.time;
        agent.SetDestination(player.position);
    }

    void OnTriggerEnter(Collider other)
    {
        TryDamage(other);
    }

    void OnTriggerStay(Collider other)
    {
        TryDamage(other);
    }

    void TryDamage(Collider other)
    {
        if (other == null || !other.CompareTag(playerTag)) return;
        if (Time.time - lastDamageTime < damageCooldown) return;

        var ph = other.GetComponent<PlayerHealth>();
        if (ph == null) ph = other.GetComponentInParent<PlayerHealth>();
        if (ph == null) return;

        lastDamageTime = Time.time;
        ph.TakeDamage();
    }
}
