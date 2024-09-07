using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    int hiScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalScoreText;
    public bool gameIsOver;
    public AudioClip Touch;
    public AudioSource audioSource;
    public Color targetColor = Color.red; // Color to use for the animation

    void Start()
    {
        score = 0;
        gameIsOver = false;
        audioSource.Play();
        hiScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHiScoreText();

        audioSource = GetComponent<AudioSource>();

    }

    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        UpdateScoreText();
        StartCoroutine(AnimateScoreText()); // Start the animation coroutine

        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt("HighScore", hiScore); // Save the new high score
            UpdateHiScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        audioSource.PlayOneShot(Touch);

    }
    private void UpdateHiScoreText()
    {
        hiScoreText.text = hiScore.ToString();
    }

    public void GameOver()
    {
        gameIsOver = true;
        Time.timeScale = 0; // Pause the game
        gameOverScreen.SetActive(true); // Show the game over screen
        finalScoreText.text = "Final Score: " + score; // Update the final score text
    }

    public void ResetHiScore()
    {
        hiScore = 0;
        PlayerPrefs.SetInt("HighScore", hiScore);
        UpdateHiScoreText();
    }

    private IEnumerator AnimateScoreText()
    {
        float duration = 0.5f; // Duration of the animation
        float elapsedTime = 0f;
        Vector3 originalScale = scoreText.transform.localScale;
        Vector3 targetScale = originalScale * 1.5f;

        Color originalColor = scoreText.color;

        // Scale up and change color to the target color
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            scoreText.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            scoreText.color = Color.Lerp(originalColor, targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure it ends at the target scale and color
        scoreText.transform.localScale = targetScale;
        scoreText.color = targetColor;

        elapsedTime = 0f;
        // Scale down and revert color to original
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            scoreText.transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            scoreText.color = Color.Lerp(targetColor, originalColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure it ends at the original scale and color
        scoreText.transform.localScale = originalScale;
        scoreText.color = originalColor;
    }
}
