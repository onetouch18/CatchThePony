using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class which operates with UI elements (scores, timer, gameover)
/// </summary>
public class Manager : MonoBehaviour
{
    public GameObject gameOverText;
    Text timerText;
    static int score;
    float timer;

    void Start()
    {
        score = 0;
        timer = 20.0f;
        timerText = GameObject.Find("Timer").GetComponent<Text>();
    }

    void Update()
    {
        TimerRun();
    }
    
    /// <summary>
    /// Increases player scores by score value
    /// </summary>
    /// <param name="scoreValue"> Incresing score by this number</param>
    public void ScoreIncrease(int scoreValue)
    {
        score += scoreValue;
        Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = score.ToString();
        if (scoreValue >= 5)
            GenerateBonus();
    }

    void GenerateBonus()
    {
        Camera.main.GetComponent<Generator>().InstatiateBonus();
    }

    void TimerRun()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(timer).ToString();
        }
        else
            EndGame();
    }

    void EndGame()
    {
        DisablePlayers();
        gameOverText.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel);
    }

    void DisablePlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
            player.SetActive(false);
    }
}
