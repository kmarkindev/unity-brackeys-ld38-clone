using UnityEngine;
using Assets.Prefabs.GameManager;

public class GameManager : MonoBehaviour
{

    public Car Car;

    public Planet Planet;

    public MeteorSpawner meteorSpawner;

    public float CurrentScore { get; private set; }
    public GamePhase GamePhase { get; private set; }

    public void GameOver()
    {
        // pause game
        // show UI
    }

    public void StartGame()
    {
        // reset game state
        // show ui
    }

    public void StartMenu()
    {
        // pause game
        // show ui
    }

}
