using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject gameOverScreen;
    public bool gameIsOver;
    public SceneTransition sceneTransition;

    public void GameOver()
    {
        gameIsOver = true;
        Time.timeScale = 0; // Pause the game
        gameOverScreen.SetActive(true); // Show the game over screen
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneTransition.TransitionToScene(currentSceneIndex);
    }

    public void StartGameSoccer()
    {
        sceneTransition.TransitionToScene(1);
    }

    public void StartGameTennis()
    {
        sceneTransition.TransitionToScene(2);
    }

    public void StartGameKarate()
    {
        sceneTransition.TransitionToScene(3);
    }

    public void StartGamePing()
    {
        sceneTransition.TransitionToScene(4);
    }

    public void GoHomeMenu()
    {
        sceneTransition.TransitionToScene(0);
    }
}
