using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int score;
    public GameObject Rock;
    public SpaceShipManager ship;
    public float spawnRate;

    private float xPos;
    private float yPos;
    private float timer;
    public float scoreSpawn;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public float spawnMult;
    public int lives;

    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<SpaceShipManager>();
        xPos = 0;
        yPos = 0;
        timer = spawnRate;
        spawnMult = 500f;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            CreateRock();
            timer = spawnRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if(scoreSpawn >= spawnMult)
        {
            scoreSpawn -= spawnMult;
            spawnMult *= 1.5f;
            spawnRate /= 1.5f;
        }
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if(lives <= 0)
        {
            
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    void CreateRock()
    {
        while (xPos < 10 && xPos > -10)
        {
            xPos = Random.Range(-15, 15);
        }
        
        
        yPos = Random.Range(-10, 10);
        

        Instantiate(Rock, new Vector3(xPos, yPos, 0f), Quaternion.identity);
        xPos = 0f;
        yPos = 0f;
    }

    public void restartGame()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + score / 500);
        score = 0;
        lives = 5;
        spawnMult = 500;
        spawnRate = 4;
    }

    public void restartGameButt()
    {
        gameOverScreen.SetActive(false);
        restartGame();
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + score / 500);
        SceneManager.LoadScene("Main");
    }
    
}
