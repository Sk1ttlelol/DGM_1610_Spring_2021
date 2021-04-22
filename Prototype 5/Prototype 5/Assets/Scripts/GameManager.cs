using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button resetButton;
    public GameObject titleScreen;

    IEnumerator SpawnTarget() //Function that spawns different sport balls and Skull Prefab, and on a spawnRate
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) //Function that updates the score when score prefabs are clicked on
    {
        score += scoreToAdd;

        scoreText.text = "Score: " + score;
    }

    public void GameOver() //Function that displays game over and reset button, also tells us that the game is not active
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        resetButton.gameObject.SetActive(true);
    }
    
    public void ResetGame() //Function that resets the scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) //Function that starts the game and starts the spawning coroutine, also allows player to choose difficulty of game
    {
        UpdateScore(0);
        scoreText.text = "Score: " + score;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
    }
}
