using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class LevelExit : MonoBehaviour
{
    [Header("Door Check")]
    public DoorController door;

    [Header("Next Scene")]
    public string nextSceneName;

    [Header("Optional")]
    public string blockedMessage = "Collect all stars first!";

    UIManager uiManager;
    bool transitioning = false;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (transitioning) return;
        if (!other.CompareTag("Player")) return;

        if (door != null && !door.IsOpen())
        {
            if (uiManager != null && !string.IsNullOrEmpty(blockedMessage))
            {
                uiManager.ShowMessage(blockedMessage);
            }
            return;
        }

        if (string.IsNullOrEmpty(nextSceneName))
        {
            Debug.LogWarning("[LevelExit] nextSceneName is not set.");
            return;
        }

        transitioning = true;
        Time.timeScale = 1f;

        // Unlock cursor on transition; gameplay scenes re-lock via PlayerHealth.Start().
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(nextSceneName);
    }
}
