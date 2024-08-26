using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuClick : MonoBehaviour
{
    public string main;
    public LevelManager lvl;

    public GameObject pauseScreen;

    
    void Start()
    {
        lvl = FindObjectOfType<LevelManager>();
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
        SceneManager.LoadScene("Clicker");
        ResumeGame();
    }

    public void ExitGame()
    {
   
        
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(main);
    }
}
