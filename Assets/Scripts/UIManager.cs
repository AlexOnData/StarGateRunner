using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("HUD Texts")]
    public TMP_Text starsText;
    public TMP_Text livesText;
    public TMP_Text messageText;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject winPanel;

    Coroutine messageRoutine;

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
        if (messageText != null) messageText.text = string.Empty;
    }

    public void UpdateStars(int collected, int total)
    {
        if (starsText != null)
            starsText.text = "Stars: " + collected + "/" + total;
    }

    public void UpdateLives(int lives)
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    public void ShowMessage(string text, float duration = 2f)
    {
        if (messageText == null) return;
        if (messageRoutine != null) StopCoroutine(messageRoutine);
        messageRoutine = StartCoroutine(MessageCoroutine(text, duration));
    }

    IEnumerator MessageCoroutine(string text, float duration)
    {
        messageText.text = text;
        yield return new WaitForSeconds(duration);
        messageText.text = string.Empty;
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        UnlockCursor();
    }

    public void ShowWin()
    {
        if (winPanel != null) winPanel.SetActive(true);
        UnlockCursor();
    }

    static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
