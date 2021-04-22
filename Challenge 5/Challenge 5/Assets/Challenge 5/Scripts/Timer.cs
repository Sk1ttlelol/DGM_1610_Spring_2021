using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 60;
    public TextMeshProUGUI timerText;
    private GameManagerX gameManagerX; // holds GameManagerX script

    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    void Update()
    {
        if(gameManagerX.isGameActive) // Function that starts the timer once game has started
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime; // Counts down in seconds
        }
        else
        {
            timeValue = 60;
        }
        ShowTime(timeValue);
    }

    void ShowTime(float timeToShow) // Function that tells the gameManager that once timer hits 0, end the game
    {
        if(timeToShow < 0)
        {
            timeToShow = 0;
            gameManagerX.GameOver();
        }

        timerText.text = "Timer: " + timeToShow;
    }
}
