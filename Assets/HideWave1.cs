using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideWave1 : MonoBehaviour {

    // Use this for initialization
    public GameObject wave1;
    public GameObject wave2;
    public GameObject wave3;
    public GameObject gameOverUI;

    public Text waveCount;

    public bool gameOver = false;
    public bool waitActive = false;
    public float waveCounter = 0;

    private float timer = 0;
    private float timerMax = 0;
    private bool closeWave1 = false;
    private bool closeWave2 = false;
    private bool closeWave3 = false;

    private bool Waited(float seconds)
    {
    timerMax = seconds;

    timer += Time.deltaTime;

    if (timer >= timerMax)
    {
        return true; //max reached - waited x - seconds
    }

    return false;
    }

    void Start()
    {
        waveCounter = 1;
    }

    void Update () {
		if (TargetsDestroyed.numberOfDestroyed == 8f && closeWave1 == false)
        {
            if (!Waited(3)) return;
            else
            {
                wave1.SetActive(false);
                wave2.SetActive(true);
                closeWave1 = true; 
            }
           
        }

        if (TargetsDestroyed.numberOfDestroyed == 16f && closeWave2 == false)
        {
            if (!Waited(3)) return;
            else
            {
                wave2.SetActive(true);
                wave3.SetActive(true);
                closeWave2 = true;
            }
        }

        if (TargetsDestroyed.numberOfDestroyed == 24f && closeWave3 == false)
        {
            if (!Waited(3)) return;
            else
            {
                // wave3.SetActive(false);
                gameOver = true;
            }
        }

        if (gameOver == true)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
            Cursor.visible = true;
        }

        //update waveCount

        if (TargetsDestroyed.numberOfDestroyed == 8f && waveCounter == 1)
        {
            waveCounter++;
        }
        if (TargetsDestroyed.numberOfDestroyed == 16f && waveCounter == 2)
        {
            waveCounter++;
        }
            waveCount.text = waveCounter.ToString();
    }
}
