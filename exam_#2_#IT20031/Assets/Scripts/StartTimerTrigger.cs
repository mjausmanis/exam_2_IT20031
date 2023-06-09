using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerTrigger : MonoBehaviour
{
    public Timer timer;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
                timer.StartTimer();
        }
    }

}
