using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public Text TimerText;
    public Text winText;
    public float currentTime;
    public bool StopWatch = false;
    public GameObject startCanvas;
    public GameObject loseCanvas;
    public GameObject winCanvas;

    public GameObject zombie;

    public ZombieController zCon;
    public PlayerController pCon;

    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = "0:00.00";
        currentTime = 0;
    }

    void Update()
    {
        if (StopWatch == true)
        {
            currentTime += Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        TimerText.text = time.ToString(@"m\:ss\.ff");

        if (pCon.playerHealth == 0)
        {
            StopTime();
            loseCanvas.SetActive(true);
        }

        if (pCon.zkill == 3)
        {
            StopTime();
            winCanvas.SetActive(true);
        }

    }

    public void StartTime()
    {
        StopWatch = true;
        startCanvas.SetActive(false);
        zombie.SetActive(true);
    }

    public void StopTime()
    {
        StopWatch = false;
    }

    public void Win()
    {
        winText.text = TimerText.text;
        winCanvas.SetActive(true);
        
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
}
