using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public TMP_Text score;
    public Button restartButton;
    public Button mainMenuButton;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        restartButton.onClick.AddListener(() =>
        {
            gameManager.StartGame();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            gameManager.StartMenu();
        });
    }

    private void Update()
    {
        score.text = gameManager.CurrentScore.ToString("0.00s");
    }

}
