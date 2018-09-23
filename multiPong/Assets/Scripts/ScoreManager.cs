using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject ball, lines;

    public Text playerScoreText, enemyScoreText, resultText;

    public int playerScore, enemyScore;

    public bool isAI;


    void Update()
    {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();

        if (playerScore == 5)
        {
            Time.timeScale = 0;
            ball.SetActive(false);
            lines.SetActive(false);
            playerScoreText.gameObject.SetActive(false);
            enemyScoreText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            resultText.text = "PLAYER WON!";
            
            StartCoroutine(Restart());
        }
        else if (enemyScore == 5)
        {
            Time.timeScale = 0;
            ball.SetActive(false);
            lines.SetActive(false);
            playerScoreText.gameObject.SetActive(false);
            enemyScoreText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            if (isAI)
                resultText.text = "ENEMY WON!";
            else if (!isAI)
                resultText.text = "PLAYER 2 WON!";

            StartCoroutine(Restart());
        }
    }

    public void AddScoreToPlayer1()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    public void AddScoreToEnemy()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
