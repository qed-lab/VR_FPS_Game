using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float gameTimer;


    // Use this for initialization
    void Start()
    {
        gameTimer = 181f;
    }

    
     void Update()
    {
        gameTimer -= Time.deltaTime;
        string minutes = Mathf.FloorToInt (gameTimer / 60F).ToString();
        string seconds = Mathf.FloorToInt (gameTimer - Mathf.FloorToInt(gameTimer / 60F) * 60).ToString("00");
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (gameTimer == 0f)
        {
            TargetsDestroyed.gameOver = true;
        }
    }
    

}