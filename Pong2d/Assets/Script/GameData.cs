using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameData : MonoBehaviour
{

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
    void Start()
    {
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
        SceneManager.LoadScene("1. Gameplay");
    }
}
