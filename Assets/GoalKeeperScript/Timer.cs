using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    private bool stopTimer;
    private float elapsedTime;

    public GameManager gameManager;

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        elapsedTime = 0;
    }

    void Update()
    {
        if (!stopTimer)
        {
            elapsedTime += Time.deltaTime;
            float time = gameTime - elapsedTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time <= 0)
            {
                stopTimer = true;
                gameManager.GameOver();
            }

            timerText.text = textTime;
            timerSlider.value = time;
        }
    }
}
