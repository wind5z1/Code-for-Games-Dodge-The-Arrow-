using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText;

    private float currentTime = 0f;
    private bool isTimeRunning = false;
    public static TimerManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeRunning)
        {
            currentTime += Time.deltaTime;

            UpdateTimeText();
        }
    }

    public void StartTimer()
    {
        isTimeRunning = true;
    }

    public void StopTimer()
    {
        isTimeRunning = false;
    }

    public float GetElapsedTime()
    {
        return currentTime;
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

  
}
