using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scenes")]
    public string firstLevelScene = "Level_1";
    public string mainMenuScene = "MainMenu";

    public void StartGame()
    {
        Time.timeScale = 1f;
        LockCursorForGameplay();
        SceneManager.LoadScene(firstLevelScene);
    }

    public void RestartCurrentLevel()
    {
        Time.timeScale = 1f;
        LockCursorForGameplay();
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        UnlockCursorForUI();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    static void LockCursorForGameplay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    static void UnlockCursorForUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
