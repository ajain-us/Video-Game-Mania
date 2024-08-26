using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class Upgrade : MonoBehaviour
{
    public MainPress player;
    private int score;
    public int[] costs;
    public float[] upVal;
    public float[] upAmount;
    public TextMeshProUGUI[] list;
    public GameObject unlimBut;
    private int[] one;
    private float[] two;
    private float[] three;

    // Start is called before the first frame update
    void Start()
    {
        list[5].text = "Coins: " + PlayerPrefs.GetInt("coins").ToString();
        player = FindObjectOfType<MainPress>();
        one = new int[costs.Length];
        two = new float[upVal.Length];
        three = new float[upAmount.Length];
        one = costs;
        two = upVal;
        three = upAmount;
    }

    // Update is called once per frame
    void Update()
    {
        score = player.score;
        if(score > 100000000)
        {
            PlayerPrefs.SetInt("coins" , PlayerPrefs.GetInt("coins") + 1);
            player.score -= 100000000;
            list[5].text = "Coins: " + PlayerPrefs.GetInt("coins").ToString();
            player.scoreMult = 1;
            player.hold = true;
            costs = one;
            upVal = two;
            upAmount = three;
            list[0].text = " Tyre Cost: " + costs[0].ToString();
            list[1].text = " Exhuast Cost: " + costs[1].ToString();
            list[2].text = " Body Cost: " + costs[2].ToString();
            list[3].text = " Interal Parts Cost: " + costs[3].ToString();
            list[4].text = " Engine Cost: " + costs[4].ToString();


        }
    
    }

    public void upgradeTyres()
    {
        if(score >= costs[0])
        {
            player.score -= costs[0];
            upVal[0] += 0.1f;
            costs[0] = (int)Math.Round(costs[0]*(upVal[0]));
            player.scoreMult *= upAmount[0];
            list[0].text = " Tyre Cost: " + costs[0].ToString();
        }
    }

    public void upgradeExh()
    {
        if (score >= costs[1])
        {
            player.score -= costs[1];
            upVal[1] += 0.1f;
            costs[1] = (int)Math.Round(costs[1] * (upVal[1]));
            player.scoreMult *= upAmount[0];
            list[1].text = " Exhuast Cost: " + costs[1].ToString();
        }
    }
    public void body()
    {
        if (score >= costs[2])
        {
            player.score -= costs[2];
            upVal[2] += 0.1f;
            costs[2] = (int)Math.Round(costs[2] * (upVal[0]));
            player.scoreMult *= upAmount[2];
            list[2].text = " Body Cost: " + costs[2].ToString();
        }
    }
    public void internals()
    {
        if (score >= costs[3])
        {
            player.score -= costs[3];
            upVal[3] += 0.01f;
            costs[3] = (int)Math.Round(costs[3] * (upVal[3]));
            player.scoreMult *= upAmount[3];
            list[3].text = " Interal Parts Cost: " + costs[3].ToString();
        }
    }
    public void engine()
    {
        if (score >= costs[4])
        {
            player.score -= costs[4];
            upVal[4] += 0.1f;
            costs[4] = (int)Math.Round(costs[4] * (upVal[4]));
            player.scoreMult *= upAmount[4];
            list[4].text = " Engine Cost: " + costs[4].ToString();
        }
    }

    
}
