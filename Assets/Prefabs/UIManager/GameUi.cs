using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    private GameManager gameManager;
    public TMP_Text score;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        score.text = gameManager.CurrentScore.ToString("0.00s");
    }

}
