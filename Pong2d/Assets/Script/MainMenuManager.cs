using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject HTPPanel;
    public GameObject TimerPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        HTPPanel.SetActive(false);
        TimerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SinglePlayerButton()
    {
        TimerPanel.SetActive(true);
    }

    public void MultiPlayerButton()
    {
        TimerPanel.SetActive(true);
    }
    
    public void BackButton()
    {
        TimerPanel.SetActive(false);
        HTPPanel.SetActive(false);
    }

    public void SetTimerButton(float Timer)
    {
        TimerPanel.SetActive(false);
        HTPPanel.SetActive(true);
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("2. Gameplay");
    }

    public void ExitGame()
    {
       Application.Quit();
    }
}
