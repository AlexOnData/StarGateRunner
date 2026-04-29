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
        SceneManager.LoadScene(firstLevelScene);
    }

    public void RestartCurrentLevel()
    {
        Time.timeScale = 1f;
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
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
}
