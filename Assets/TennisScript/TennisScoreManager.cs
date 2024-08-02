using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TennisScoreManager : MonoBehaviour
{
    private int scoreP1 = 0, scoreP2 = 0;
    public TMP_Text TxtScoreP1, TxtScoreP2, TxtResult;
    public bool EndGame = false; 

    public void AddScore(int p)
    {
        if (p == 1) scoreP1++;
        if (p == 2) scoreP2++;
        TxtScoreP1.text = scoreP1.ToString();
        TxtScoreP2.text = scoreP2.ToString();

        if(scoreP1 == 11)
        {
            TxtResult.text = "You Win !";
            EndGame = true;
        }

        if (scoreP2 == 11)
        {
            TxtResult.text = "You Loose !";
            EndGame = true;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
