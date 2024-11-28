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
    public GameObject BallSelectionPanel;

    [Header("Bola Prefabs")]
    public GameObject BallPrefab1;
    public GameObject BallPrefab2;
    public GameObject BallPrefab3;
    private GameObject selectedBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        HTPPanel.SetActive(false);
        TimerPanel.SetActive(false);
        BallSelectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SinglePlayerButton()
    {
        GameData.instance.isSinglePlayer = true;
        TimerPanel.SetActive(true);
        soundManager.instance.UIClickSfx();
    }

    public void MultiPlayerButton()
    {
        GameData.instance.isSinglePlayer = false;
        TimerPanel.SetActive(true);
        soundManager.instance.UIClickSfx();
    }
    
    public void BackButton()
    {
        TimerPanel.SetActive(false);
        HTPPanel.SetActive(false);
        soundManager.instance.UIClickSfx();
    }

    public void SetTimerButton(float Timer)
    {
        GameData.instance.gameTimer = Timer;
        TimerPanel.SetActive(false);
        HTPPanel.SetActive(true);
        soundManager.instance.UIClickSfx();
    }

    public void StartBtn()
    {
        HTPPanel.SetActive(false);
        BallSelectionPanel.SetActive(true);
        soundManager.instance.UIClickSfx();
    }

    public void SelectBall1()
    {
        selectedBallPrefab = BallPrefab1;
        BallSelectionPanel.SetActive(false); // Sembunyikan panel bola setelah memilih
        StartGame();
    }

    public void SelectBall2()
    {
        selectedBallPrefab = BallPrefab2;
        BallSelectionPanel.SetActive(false); // Sembunyikan panel bola setelah memilih
        StartGame();
    }

    public void SelectBall3()
    {
        selectedBallPrefab = BallPrefab3;
        BallSelectionPanel.SetActive(false); // Sembunyikan panel bola setelah memilih
        StartGame();
    }

    public void StartGame()
    {
        GameData.instance.selectedBallPrefab = selectedBallPrefab; // Menyimpan pilihan bola ke GameData
        SceneManager.LoadScene("2. Gameplay");
        soundManager.instance.UIClickSfx();
    }

    public void ExitGame()
    {
       Application.Quit();
    }
}
