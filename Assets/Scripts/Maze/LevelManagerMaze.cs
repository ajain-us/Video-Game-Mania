using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class LevelManagerMaze : MonoBehaviour
{

    public float timer;
    public float addedTime;
    private float timerReal;
    private float addedTimeReal;
    public float score;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI time;

    public Vector3[] possibleSpawn;
    
    public GameObject gas;

    private GameObject curent;

    private Maze player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Maze>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerReal > 0)
        {
            time.text = (int)timerReal + " seconds";
            timerReal -= Time.deltaTime;
        }
        else
        {
            time.text = "Dead";
            GameOver();
        }
        scoreTxt.text = score + "";
    }

    public void addTime()
    {
        int index = Random.Range(0, possibleSpawn.Length);



        timerReal += addedTimeReal;
        if(addedTimeReal > 8)
        {
            addedTimeReal -= 1f;
        }
        
        score += 1f;
        curent = Instantiate(gas, possibleSpawn[index], Quaternion.identity);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + (int)score / 10);
        score = 0f;
        timerReal = timer;
        addedTimeReal = addedTime;
        Destroy(curent);
        curent = Instantiate(gas, new Vector3(2,-3,0), Quaternion.identity);
        player.Reset();

    }
}
