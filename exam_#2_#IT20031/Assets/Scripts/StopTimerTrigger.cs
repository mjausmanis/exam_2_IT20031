using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StopTimerTrigger : MonoBehaviour
{
    private const string hsKey = "HighScore";
    public Timer timer;
    private float hs;
    private float currentTime;
    private GameObject HSUI;
    private TextMeshProUGUI prevHS;
    private TextMeshProUGUI yourTime;

    void Awake() {
        GameObject hud = GameObject.Find("HUD");
        HSUI = hud.transform.Find("Win").gameObject;
        prevHS = HSUI.transform.Find("PrevHS").gameObject.GetComponent<TextMeshProUGUI>();
        yourTime = HSUI.transform.Find("CurTime").gameObject.GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            timer.StopTimer();
            currentTime = timer.GetEndTime();
            HandleComplete();
        }
    }

    private void HandleComplete() {
        hs = GetHighScore();
        UpdateHighScore();
        StartCoroutine(UpdateHSUI());
    }

    public float GetHighScore() {
        if (PlayerPrefs.HasKey(hsKey)) {
            return PlayerPrefs.GetFloat(hsKey);
        }
        return 0;
    }

    private void UpdateHighScore() {
        if (hs == 0) {
            PlayerPrefs.SetFloat(hsKey, currentTime);
        }
        if (hs != 0) {
            if (currentTime < hs) {
                PlayerPrefs.SetFloat(hsKey, currentTime);
            }
        }
    
    }

    IEnumerator UpdateHSUI() {
        prevHS.text = hs.ToString("F4");
        yourTime.text = currentTime.ToString("F4");
        HSUI.SetActive(true);
        Time.timeScale = 0.1f;

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
