using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //int level = 0;
    //int countLevel = 0;
    bool GameHasPaused = false;

    public TextMeshProUGUI Score;
    public GameObject PanelStart;
    public GameObject PanelComplete;
    public GameObject PanelGameOver;
    public AudioSource GameOverAudio;
    public AudioSource ApplauseAudio;

    private void Start() {
        Time.timeScale = 0;
    }

    public void AddPoint() {
        //TextMeshProUGUI Score = FindObjectOfType<TextMeshProUGUI>();
        if (int.TryParse(Score.text, out int result)) {
            if (result >= 19) {
                GameAccomplished();
            }

            /*countLevel++;
            if (countLevel == 10) {
                countLevel = 0;
                level++;
                decimal value = Math.Round((decimal)level / 1000, 3);
                Debug.LogWarning(0.100f - (float)value);
                FindObjectOfType<Enemy>().TimeCreate = 0.100f - (float)value;             
            }

            if (level == 10) {
                GameAccomplished();
            }*/

            //int points = result + 1;            
            Score.text = (result + 1) + "";
        }
    }  

    public void GameAccomplished() {
        ApplauseAudio.Play();
        PanelComplete.SetActive(true);
    }

    public void StartGame() {
        PanelStart.SetActive(false);
        Time.timeScale = 1;
    }  

    public void PauseGame() {
        GameHasPaused = !GameHasPaused;
        Time.timeScale = GameHasPaused ? 1 : 0;        
    }

    public void EndGame() { 
        if(!PanelComplete.activeSelf) {
            Debug.LogWarning("Game Over");   
            GameOverAudio.Play();       
            PanelGameOver.SetActive(true);
        }

        /*if (GameHasEnded == false) {
            GameHasEnded = true;
            Debug.LogWarning("Game Over");   
            GameOverAudio.Play();       
            PanelGameOver.SetActive(true);
            //Invoke("Restart", 2f);
        }*/
    }

    public void RestartGame() {
        ApplauseAudio.Stop();
        GameOverAudio.Stop();
        Restart();
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
