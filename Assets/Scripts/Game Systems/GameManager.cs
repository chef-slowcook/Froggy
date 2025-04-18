using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
    [Header("Game State")]
    [SerializeField] private GameState currentGameState = GameState.MainMenu;
    [Header("UI References")]
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseMenuUI;
    [Header("Game Settings")]
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives = 3;
    [SerializeField] private int score = 0;
    [Header("Scene Objects")]
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private GameObject playerInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
