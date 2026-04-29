using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Playing, GameOver, Win }

    [Header("Stars")]
    public int totalStarsInLevel = 3;
    public int starsCollected = 0;

    [Header("Refs")]
    public DoorController levelDoor;
    public UIManager uiManager;

    public GameState State { get; private set; } = GameState.Playing;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (uiManager == null) uiManager = FindFirstObjectByType<UIManager>();
        if (levelDoor == null) levelDoor = FindFirstObjectByType<DoorController>();
    }

    void Start()
    {
        if (uiManager != null)
        {
            uiManager.UpdateStars(starsCollected, totalStarsInLevel);
        }
    }

    public void AddStar()
    {
        if (State != GameState.Playing) return;

        starsCollected++;

        if (uiManager != null)
        {
            uiManager.UpdateStars(starsCollected, totalStarsInLevel);
        }

        if (starsCollected >= totalStarsInLevel && levelDoor != null)
        {
            levelDoor.OpenDoor();
            if (uiManager != null) uiManager.ShowMessage("Door opened!");
        }
    }

    public void SetGameOver()
    {
        if (State != GameState.Playing) return;
        State = GameState.GameOver;
        if (uiManager != null) uiManager.ShowGameOver();
    }

    public void SetWin()
    {
        if (State == GameState.Win) return;
        State = GameState.Win;
        if (uiManager != null) uiManager.ShowWin();
    }
}
