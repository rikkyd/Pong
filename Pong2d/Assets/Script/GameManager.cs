using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Prefab")]
    public GameObject BallPrefab;

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
        SpawnBall();
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        
        player2WinUI.SetActive(false);
        player1WinUI.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("1. Main Menu");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("2. Gameplay");
    }

    public void SpawnBall()
    {
        Debug.Log("Muncul Bola");
        StartCoroutine("DelaySpawn");
    }

    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(1);
        Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);

    }
}
