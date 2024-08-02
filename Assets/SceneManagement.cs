using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameOverScreen;
    public bool gameIsOver;


    public void GameOver()
    {
        gameIsOver = true;
        Time.timeScale = 0; // Pause the game
        gameOverScreen.SetActive(true); // Show the game over screen
    }
    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
    public void StartGameSoccer()
    {
        SceneManager.LoadScene(1);
    }

    public void StartGameTennis()
    {
        SceneManager.LoadScene(2);
    }

    public void GoHomeMenu()
    {
        SceneManager.LoadScene(0);
    }
}
