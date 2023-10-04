using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ScoreManager scoreManager;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        scoreManager.ResetScore();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        scoreManager.enabled = false; // Disable the ScoreManager script temporarily
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
}
