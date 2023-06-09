using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool timerStarted = false;
    private float timerTime;
    private float endTime;
    

    private TextMeshProUGUI timerUI; 

    void Awake() {
        timerUI = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timerStarted) {
            timerTime += Time.deltaTime;
            timerUI.text = timerTime.ToString("F2");
        }
    }

    public void StartTimer() {
        timerTime = 0f;
        timerStarted = true;
    }

    public void StopTimer() {
        endTime = timerTime;
        timerStarted = false;
    }

    public float GetEndTime() {
        return endTime;
    }
}
