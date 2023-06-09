using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private GameObject dieUI;

    void Awake() {
        GameObject hud = GameObject.Find("HUD");
        dieUI = hud.transform.Find("Die").gameObject;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        dieUI.SetActive(true);
        Time.timeScale = 0.3f;

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
