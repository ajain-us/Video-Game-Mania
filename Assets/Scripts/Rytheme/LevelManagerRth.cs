using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class LevelManagerRth : MonoBehaviour
{
    public bool canTap;
    
    
    public float timeBetweenSpawn;
    public float speedOriginal;
    private float timerBetweenSpawn;
    private float realSpeed;
    public ArrayList allHit;
    public GameObject[] possible;


    public TextMeshProUGUI scoreTxt;
    public float score;



    // Start is called before the first frame update
    void Start()
    {
        canTap = false;
        allHit = new ArrayList();
        timerBetweenSpawn = timeBetweenSpawn;
        realSpeed = speedOriginal;
    }

    // Update is called once per frame
    void Update()
    {
        Event e = Event.current;

        if(timerBetweenSpawn > 0)
        {
            timerBetweenSpawn -= Time.deltaTime;
        }
        else
        {
            if(UnityEngine.Random.Range(0f,1f) > 0.5f)
            {
                switch ((int)UnityEngine.Random.Range(0f, 4f))
                {
                    case 0:
                        
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            else
            {

            }
            timerBetweenSpawn = timeBetweenSpawn;
        }



        if (e.isKey)
        {
            if (true)
            {

            }
            switch (e.keyCode)
            {
                case (KeyCode.W):

                case (KeyCode.A):

                case (KeyCode.S):

                case (KeyCode.D):

                case (KeyCode.DownArrow):

                case (KeyCode.UpArrow):

                case (KeyCode.RightArrow):

                case (KeyCode.LeftArrow):

                default:
                    break;
            }
        }
        
    }
}
