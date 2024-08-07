using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TennisScoreManager : MonoBehaviour
{
    private int[] tennisScores = { 0, 15, 30, 40 };
    private int scoreP1Index = 0, scoreP2Index = 0;
    public TMP_Text TxtScoreP1, TxtScoreP2, TxtResult;
    public GameObject RestartButton, HomeButton;
    public bool EndGame = false;

    private void Start()
    {
        RestartButton.SetActive(false);
        HomeButton.SetActive(false);
        UpdateScoreText();
    }

    public void AddScore(int p)
    {
        if (EndGame) return;

        if (p == 1)
        {
            scoreP1Index++;
            if (scoreP1Index > 3)
            {
                TxtResult.text = "Player 1 Wins!";
                EndGame = true;
            }
        }
        else if (p == 2)
        {
            scoreP2Index++;
            if (scoreP2Index > 3)
            {
                TxtResult.text = "Player 2 Wins!";
                EndGame = true;
            }
        }

        UpdateScoreText();

        if (EndGame)
        {
            RestartButton.SetActive(true);
            HomeButton.SetActive(true);
        }
    }

    private void UpdateScoreText()
    {
        TxtScoreP1.text = scoreP1Index > 3 ? "Win" : tennisScores[scoreP1Index].ToString();
        TxtScoreP2.text = scoreP2Index > 3 ? "Win" : tennisScores[scoreP2Index].ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
