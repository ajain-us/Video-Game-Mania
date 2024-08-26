using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class LevelManagerFlap : MonoBehaviour
{
    public GameObject Pillar;
    public int score;
    public float topBound;
    public float lowerBound;
    public TextMeshProUGUI scoreTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GeneratePill();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rock")
        {
            GeneratePill();
        }
        
    }

    public void GeneratePill()
    {
        float posRan = Random.Range(topBound, lowerBound);
        Instantiate(Pillar, new Vector3(10f, posRan, 0f), Quaternion.identity);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + (int)score / 5);
        SceneManager.LoadScene("FlappyBird");

    }
}
