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

    // Start is called before the first frame update
    void Start()
    {
        newGameButton.onClick.AddListener(StartGame);
        titleScreenButton.onClick.AddListener(ResetGame);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameOn = false;
    }

    public void StartGame()
    {
        startScreen.gameObject.SetActive(false);
        isGameOn = true;
        Debug.Log("newGameButton was clicked");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
