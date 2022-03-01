using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    bool gameOver = false;
    int lives = 3;
    public GameObject LivesPanel;
    public GameObject GameOverPanel;

    public Text ScoreText;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        GameOverPanel.SetActive(false);
    }

    public void Increment()
    {
        if (!gameOver)
        {
            score++;
            ScoreText.text = score.ToString();
            //print(score);
        }
    }

    public void DecreaseLives()
    {
        if(lives > 0)
        {
            lives--;
            print(lives);
            LivesPanel.transform.GetChild(lives).gameObject.SetActive(false);
        }
        else if(lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
              
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawingCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().IsMove = false;
        GameOverPanel.SetActive(true);
        print("Game Over");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
