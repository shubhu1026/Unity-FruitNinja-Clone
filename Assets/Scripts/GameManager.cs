using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighscoreText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);

        GetHighscore();
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += 2;
        scoreText.text = "Your Score: "  + score.ToString();

        if(score > highscore)
        {
            PlayerPrefs.SetInt("Highscore",score);
            highscoreText.text = "Highscore: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighscoreText.text = "Highscore: " + highscore.ToString();

        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = "Your Score: " + score.ToString();

        gameOverPanel.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
}
