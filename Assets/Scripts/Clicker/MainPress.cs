using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class MainPress : MonoBehaviour
{
    public int score;
    public float scoreMult;
    public TextMeshProUGUI scoreTxt;
    public bool hold;
    public TextMeshProUGUI clickPer;
    // Start is called before the first frame update
    void Start()
    {
        scoreMult = 1;
        hold = false;
    }

    // Update is called once per frame
    void Update()
    {

        clickPer.text = "Earn: " + ((int)(1 * scoreMult)).ToString() +  " dollars per race!";
        if (!hold)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                score += (int)(1 * scoreMult);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                score += (int)(1 * scoreMult);
            }
        }
        
        scoreTxt.text = "Money: " + score.ToString();
    }
}
