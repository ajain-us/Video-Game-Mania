using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class FlapUi : MonoBehaviour
{
    public string main;
    public LevelManagerFlap info;

    public GameObject pauseScreen;


    void Start()
    {
        pauseScreen.SetActive(false);
        info = FindObjectOfType<LevelManagerFlap>();
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


        info.GameOver();
        ResumeGame();
    }

    public void ExitGame()
    {

        info.GameOver();
        Time.timeScale = 1f;

        SceneManager.LoadScene(main);
    }
}
