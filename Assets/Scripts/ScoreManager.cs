using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public Text highestScoreText;
    public int score = 0;

    private float scoreUpdateInterval = 0.1f; // Update interval for score display
    private bool isIncrementing = true; // Flag to control score increment

    private void Start()
    {
        StartCoroutine(IncrementScore());
        highestScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    private IEnumerator IncrementScore()
    {
        while (isIncrementing) // Only increment when the flag is true
        {
            yield return new WaitForSeconds(scoreUpdateInterval);
            score += 1; // Increment the score by 1
        }
    }

    private void Update()
    {
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
        finalScoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highestScoreText.text = score.ToString();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
        Debug.Log("Score reset to 0.");
    }

    public void PauseIncrement()
    {
        isIncrementing = false; // Pause the score increment
    }

    public void ResumeIncrement()
    {
        isIncrementing = true; // Resume the score increment
    }
}
