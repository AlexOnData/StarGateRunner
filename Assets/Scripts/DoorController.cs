using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("State")]
    public bool isOpen = false;

    [Header("Refs")]
    public Animator animator;
    public AudioSource openAudio;
    public Collider blockingCollider;

    [Header("Animator")]
    public string openTriggerName = "Open";

    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;

        if (animator != null && !string.IsNullOrEmpty(openTriggerName))
        {
            animator.SetTrigger(openTriggerName);
        }

        if (openAudio != null)
        {
            openAudio.Play();
        }

        // Disable blocking collider so the player can walk through.
        if (blockingCollider != null)
        {
            blockingCollider.enabled = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
