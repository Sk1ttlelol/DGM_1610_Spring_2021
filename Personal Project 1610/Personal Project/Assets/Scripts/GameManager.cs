using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool isGameOn;

    public TextMeshProUGUI gameOverTxt;
    public Button newGameButton;
    public Button titleScreenButton;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;

    // Start is called before the first frame update
    void Start()
    {
        newGameButton.onClick.AddListener(StartGame);
        titleScreenButton.onClick.AddListener(ResetGame);
    }

    public void GameOver() //Function that ends the game
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameOn = false;
    }

    public void StartGame() //Function that starts the game
    {
        startScreen.gameObject.SetActive(false);
        isGameOn = true;
        Debug.Log("newGameButton was clicked");
    }

    public void ResetGame() //Function that reloads the scene when reset is pushed
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame() //Function that tells the player they won
    {
        isGameOn = false;
        youWinScreen.gameObject.SetActive(true);
        Debug.Log("You Win");
    }
}
