using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class TetrisUi : MonoBehaviour
{
    public string main;
    public TextMeshProUGUI scoreText;
    public Board info;

    public GameObject pauseScreen;


    void Start()
    {
        pauseScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        scoreText.text = "Score: " + info.score;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void RestartGame()
    {
        

        info.GameOver();
        ResumeGame();
    }

    public void ExitGame()
    {

        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + info.score / 50000);
        Time.timeScale = 1f;

        SceneManager.LoadScene(main);
    }
}
