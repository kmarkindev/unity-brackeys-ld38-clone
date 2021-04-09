using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUi : MonoBehaviour
{

    public Button playButton;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        playButton.onClick.AddListener(() =>
        {
            gameManager.StartGame();
        });

    }

}
