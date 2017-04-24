using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverallGameHandler : MonoBehaviour {

    public bool GameOver = false;
    private bool finishedGame = false;
    public GameObject EndGameCamera;
    public float Timer;
    public Text EndGameTimerMinutes;

    void Start()
    {
        Timer = 0;
        EndGameCamera.SetActive(false);
    }
    void Update()
    {
        if (!finishedGame)
        {
            Timer += Time.deltaTime;

            if (GameOver)
            {
                EndGameTimerMinutes.text = (Math.Round(Timer, 0) / 60).ToString() + " minutes";
                finishedGame = true;
                EndGameCamera.SetActive(true);
            }
        }
    }

}
