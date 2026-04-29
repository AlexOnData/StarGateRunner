using System.Collections;
using UnityEngine;

public class TimedSpikes : MonoBehaviour
{
    [Header("Timing")]
    public float activeTime = 2f;
    public float inactiveTime = 2f;
    public float startDelay = 0f;

    [Header("Refs")]
    public Collider damageCollider;
    public GameObject visual;

    [Header("Audio")]
    public AudioSource activateAudio;

    bool isActive = false;

    void Reset()
    {
        if (damageCollider == null) damageCollider = GetComponent<Collider>();
        if (damageCollider != null) damageCollider.isTrigger = true;
    }

    void Start()
    {
        SetActiveState(false);
        StartCoroutine(CycleRoutine());
    }

    IEnumerator CycleRoutine()
    {
        if (startDelay > 0f) yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SetActiveState(false);
            yield return new WaitForSeconds(inactiveTime);

            SetActiveState(true);
            yield return new WaitForSeconds(activeTime);
        }
    }

    void SetActiveState(bool value)
    {
        isActive = value;
        if (damageCollider != null) damageCollider.enabled = value;
        if (visual != null) visual.SetActive(value);
        if (value && activateAudio != null) activateAudio.Play();
    }

    void OnTriggerStay(Collider other)
    {
        if (!isActive) return;
        if (!other.CompareTag("Player")) return;

        var ph = other.GetComponent<PlayerHealth>();
        if (ph == null) ph = other.GetComponentInParent<PlayerHealth>();
        if (ph == null) return;

        ph.TakeDamage();
    }
}
