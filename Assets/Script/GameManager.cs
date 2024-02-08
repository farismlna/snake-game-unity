using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playButton;
    public GameObject restartButton;
    public Text gameOver;
    public GameObject welcomeText;
    public GameObject panel;
    public Text scoreText;
    public int score;

    private void Awake()
    {
        Pause();
        restartButton.SetActive(false);
        gameOver.enabled = false;
    }

    public void Play()
    {
        Time.timeScale = 1;
        player.SetActive(true);

        playButton.SetActive(false);
        // restartButton.SetActive(false);
        welcomeText.SetActive(false);
        panel.SetActive(false);
        FindObjectOfType<FoodPlacement>().RandomizePosition();
        score = 0;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        player.SetActive(false);
    }

    public void GameOver()
    {
        panel.SetActive(true);
        gameOver.enabled = true;
        restartButton.SetActive(true);
        scoreText.enabled = true;

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        switch (score)
        {
            case <= 10:
                gameOver.text = "Mending uninstall dah";
                break;

            case <= 20:
                gameOver.text = "Skill issue bro";
                break;

            case < 30:
                gameOver.text = "Ohh bisa juga ternyata";
                break;

            case > 30:
                gameOver.text = "Gacor kang";
                break;
        }
    }

    private void Update()
    {

    }
}
