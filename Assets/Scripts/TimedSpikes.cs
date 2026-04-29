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

    [Header("Animation")]
    public float transitionDuration = 0.3f;
    public float hiddenYOffset = -0.5f;

    [Header("Audio")]
    public AudioSource activateAudio;

    bool isActive = false;
    Vector3 visualUpPosition;
    Vector3 visualDownPosition;

    void Reset()
    {
        if (damageCollider == null) damageCollider = GetComponent<Collider>();
        if (damageCollider != null) damageCollider.isTrigger = true;
    }

    void Start()
    {
        if (visual != null)
        {
            visualUpPosition = visual.transform.localPosition;
            visualDownPosition = visualUpPosition + Vector3.up * hiddenYOffset;
            visual.transform.localPosition = visualDownPosition;
        }

        if (damageCollider != null) damageCollider.enabled = false;
        isActive = false;

        StartCoroutine(CycleRoutine());
    }

    IEnumerator CycleRoutine()
    {
        if (startDelay > 0f) yield return new WaitForSeconds(startDelay);

        while (true)
        {
            yield return new WaitForSeconds(inactiveTime);

            // Rise
            if (activateAudio != null) activateAudio.Play();
            yield return AnimateVisual(visualDownPosition, visualUpPosition);
            isActive = true;
            if (damageCollider != null) damageCollider.enabled = true;

            yield return new WaitForSeconds(activeTime);

            // Lower
            isActive = false;
            if (damageCollider != null) damageCollider.enabled = false;
            yield return AnimateVisual(visualUpPosition, visualDownPosition);
        }
    }

    IEnumerator AnimateVisual(Vector3 from, Vector3 to)
    {
        if (visual == null || transitionDuration <= 0f)
        {
            if (visual != null) visual.transform.localPosition = to;
            yield break;
        }

        float t = 0f;
        while (t < transitionDuration)
        {
            t += Time.deltaTime;
            float p = Mathf.Clamp01(t / transitionDuration);
            visual.transform.localPosition = Vector3.Lerp(from, to, p);
            yield return null;
        }
        visual.transform.localPosition = to;
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
        if (!isActive) return;
        if (!other.CompareTag("Player")) return;

        var ph = other.GetComponent<PlayerHealth>();
        if (ph == null) ph = other.GetComponentInParent<PlayerHealth>();
        if (ph == null) return;

        ph.TakeDamage();
    }
}
