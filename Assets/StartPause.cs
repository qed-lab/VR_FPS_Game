using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPause : MonoBehaviour {


    public GameObject pauseMenuUI;
    public AudioSource backgroundMusic;
    private CountdownManager CDM;
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.visible = false;
        CDM = GameObject.Find("321GO").GetComponent<CountdownManager>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
            Time.timeScale = 1f;
            

        }
    }
    
    void StartGame()
    {
        if (CDM.countDownDone == true)
        {
            backgroundMusic.Play();
            pauseMenuUI.SetActive(false);
            Cursor.visible = false;
        }
    }

}
