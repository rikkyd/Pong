using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Variable instance makes a class that can be called by other classes easily
    public static GameData instance;

    public bool isSinglePlayer;
    public float gameTimer;
     public GameObject selectedBallPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
 
    }
}
