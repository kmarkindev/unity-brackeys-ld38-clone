using UnityEngine;
using Assets.Prefabs.GameManager;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public Car Car;

    public Planet Planet;

    public MeteorSpawner meteorSpawner;

    public float CurrentScore { get; private set; }
    public GamePhase GamePhase { get; private set; }

    public UnityEvent OnGameOver;
    public UnityEvent OnGameStart;
    public UnityEvent OnStartMenu;

    public void Start()
    {
        //StartMenu();
        StartGame();
    }

    private void Update()
    {
        if (GamePhase == GamePhase.Gameplay)
            CurrentScore += Time.deltaTime;
    }

    public void GameOver()
    {
        GamePhase = GamePhase.GameOver;
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        CurrentScore = 0;
        GamePhase = GamePhase.Gameplay;
        OnGameStart?.Invoke();
    }

    public void StartMenu()
    {
        GamePhase = GamePhase.StartMenu;
        OnStartMenu?.Invoke();
    }

}
