using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Manager<GameManager>
{
    [HideInInspector]
    public int PlayerScore = 0;
    public Text ScoreCounter;
    public GameObject PauseMenu;
    public bool IsPaused = false;

    public void IncrementScore(int i) {
        PlayerScore += i;
        ScoreCounter.text = "Score: " + PlayerScore;
;    }

    public void ResetScore() {
        PlayerScore = 0;
    }

    public void DefferedResetLevel() {
        Invoke("ResetLevel", 2f);
    }

    public void ResetLevel() {
        ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsPaused) {
                IsPaused = false;
                UnPause();
            } else {
                Pause();
                IsPaused = true;
            }
        }
    }

    private void Pause() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void UnPause() {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
