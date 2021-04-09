using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject startMenuUi;
    public GameObject gameUi;
    public GameObject gameOverUi;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.OnGameStart.AddListener(() =>
        {
            HideGameOverUi();
            HideStartMenuUi();
            ShowGameUi();
        });

        gameManager.OnGameOver.AddListener(() =>
        {
            HideGameUi();
            ShowGameOverUi();
        });

        gameManager.OnStartMenu.AddListener(() =>
        {
            HideGameUi();
            HideGameOverUi();
            ShowStartMenuUi();
        });

    }

    public void ShowStartMenuUi()
    {
        startMenuUi.SetActive(true);
    }

    public void HideStartMenuUi()
    {
        startMenuUi.SetActive(false);
    }

    public void ShowGameUi()
    {
        gameUi.SetActive(true);
    }

    public void HideGameUi()
    {
        gameUi.SetActive(false);
    }

    public void ShowGameOverUi()
    {
        gameOverUi.SetActive(true);
    }

    public void HideGameOverUi()
    {
        gameOverUi.SetActive(false);
    }

}
