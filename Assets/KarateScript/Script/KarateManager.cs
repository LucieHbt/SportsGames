using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class KarateManager : MonoBehaviour
{
    int score;
    int lives;
    public TextMeshProUGUI scoreText, livesText;
    public GameObject RestartButton, HomeButton, gameOverText;
    public bool EndGame;
    public AudioClip gameOverSound;
    private AudioSource audioSource;
    private bool hasPlayedGameOverSound = false;

    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false);
        HomeButton.SetActive(false);
        gameOverText.SetActive(false);
        score = 0;
        lives = 3;

        audioSource = GetComponent<AudioSource>();
    }

    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text = score.ToString();
    }

    public void UpdateLives()
    {
        if (EndGame == false)
        {
            lives --;
            livesText.text = "Lives: " + lives;
            
            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        if (!hasPlayedGameOverSound)
        {
            if (gameOverSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(gameOverSound);
            }
            hasPlayedGameOverSound = true;
        }

        EndGame = true;
        gameOverText.SetActive(true);
        RestartButton.SetActive(true);
        HomeButton.SetActive(true);
    }
}
