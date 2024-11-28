using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Game Settings")]
    public int player1Score;
    public int player2Score;
    public float timer;
    public bool isOver;
    public bool goldenGoal;
    public bool isSpawnPowerUp;
    public GameObject ballSpawned;

    [Header("Prefab")]
    public GameObject BallPrefab;
    public GameObject[] powerUp;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    [Header("InGame UI")]
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI player1ScoreTxt;
    public TextMeshProUGUI player2ScoreTxt;
    public GameObject goldenGoalUI;

    [Header("Game Over UI")]
    public GameObject player1WinUI;
    public GameObject player2WinUI;
    public GameObject youWin;
    public GameObject youLose;
    // Start is called before the first frame update

    private void Awake() // memvalidasi
    {
            
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        
        player2WinUI.SetActive(false);
        player1WinUI.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);

        goldenGoalUI.SetActive(false);

        timer = GameData.instance.gameTimer;
        isOver = false;
        goldenGoal = false;

        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreTxt.text = player1Score.ToString();
        player2ScoreTxt.text = player2Score.ToString();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timer / 60); 
            float seconds = Mathf.FloorToInt(timer % 60);
            timerTxt.text = string.Format("{00:00}:{01:00}", minutes, seconds);

            if (seconds % 20 == 0 && !isSpawnPowerUp)
            {
                StartCoroutine("SpawnPowerUp");
            }
        }

        if (timer <= 0f && !isOver)
        {
            timerTxt.text = "00:00";

        if (player1Score == player2Score)
        {
        if (!goldenGoal)
        {
            goldenGoal = true;
            Ball[] ball = FindObjectsOfType<Ball>();
            for (int i = 0; i < ball.Length; i++)
            {
                Destroy(ball[i].gameObject);
            }
            goldenGoalUI.SetActive(true);
            SpawnBall();
            }
        }
        else
        {
            GameOver();
        }
    }
}

    public IEnumerator SpawnPowerUp()
    {
        isSpawnPowerUp = true;
        Debug.Log("Power Up");
        int rand = Random.Range(0, powerUp.Length);
        Instantiate(powerUp[rand], new Vector3(Random.Range(-3.2f, 3.2f), Random.Range(-2.35f, 2.25f), 0), Quaternion.identity);
        yield return new WaitForSeconds(1);
        isSpawnPowerUp = false; 

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        soundManager.instance.UIClickSfx();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        soundManager.instance.UIClickSfx();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("1. Main Menu");
        soundManager.instance.UIClickSfx();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("2. Gameplay");
        soundManager.instance.UIClickSfx();
    }

    public void SpawnBall()
    {
        Debug.Log("Muncul Bola");
        StartCoroutine("DelaySpawn");
    }

    public void GameOver()
    {
        soundManager.instance.UIClickSfx();
        isOver = true;
        Debug.Log("Game Over");
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);

        if (GameData.instance.isSinglePlayer) 
        {
            if (player1Score > player2Score)
            {
                youWin.SetActive(true);
            }
            if (player1Score < player2Score)
            {
                 youLose.SetActive(true);
            }
        }
        else 
        {
            if (player1Score > player2Score)
            {
                player1WinUI.SetActive(true);
            }
            if (player1Score < player2Score)
            {
                player2WinUI.SetActive(true);      
            }
        }
    }
    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(3);
        if (ballSpawned == null)
        {
            ballSpawned = Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
