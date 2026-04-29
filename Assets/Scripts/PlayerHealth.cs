using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lives")]
    public int maxLives = 3;
    public int currentLives;

    [Header("Damage")]
    public float damageCooldown = 1f;
    float lastDamageTime = -999f;

    [Header("Respawn")]
    public Transform respawnPoint;
    public float respawnDelay = 0.5f;

    [Header("Refs")]
    public UIManager uiManager;
    public AudioSource damageAudio;

    Vector3 fallbackRespawnPosition;
    Quaternion fallbackRespawnRotation;
    CharacterController characterController;

    void Start()
    {
        currentLives = maxLives;
        characterController = GetComponent<CharacterController>();
        fallbackRespawnPosition = transform.position;
        fallbackRespawnRotation = transform.rotation;

        if (uiManager == null) uiManager = FindFirstObjectByType<UIManager>();
        if (uiManager != null) uiManager.UpdateLives(currentLives);
    }

    public void TakeDamage()
    {
        if (currentLives <= 0) return;
        if (Time.time - lastDamageTime < damageCooldown) return;

        lastDamageTime = Time.time;
        currentLives--;

        if (damageAudio != null) damageAudio.Play();
        if (uiManager != null) uiManager.UpdateLives(currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnDelay);
        }
    }

    void Respawn()
    {
        Vector3 pos = respawnPoint != null ? respawnPoint.position : fallbackRespawnPosition;
        Quaternion rot = respawnPoint != null ? respawnPoint.rotation : fallbackRespawnRotation;

        // CharacterController must be disabled before teleporting, otherwise it fights the move.
        if (characterController != null)
        {
            characterController.enabled = false;
            transform.SetPositionAndRotation(pos, rot);
            characterController.enabled = true;
        }
        else
        {
            transform.SetPositionAndRotation(pos, rot);
        }
    }

    void GameOver()
    {
        if (GameManager.Instance != null) GameManager.Instance.SetGameOver();
        else if (uiManager != null) uiManager.ShowGameOver();
    }
}
