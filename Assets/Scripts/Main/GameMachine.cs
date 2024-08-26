using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMachine : MonoBehaviour
{

    private Player myPlayer;
    public string levelTextName;
    public string levelToLoad;
    public int cost;
    private bool unlocked;
    private float timeBetween;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        
        if (PlayerPrefs.HasKey(levelTextName)){
            if (PlayerPrefs.GetInt(levelTextName) == 1)
            {
                unlocked = true;
            }
            else { unlocked = false; }
        }
        
        else
        {
            PlayerPrefs.SetInt(levelTextName, 0);
        }

        timeBetween = 0.25f;
        timer = timeBetween;
    }

    // Update is called once per frame
    void Update()
    {

        
       

        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.tag == "P-main")
        {
            if (unlocked)
            {
                myPlayer.interactText.text = "Press E to load: " + levelTextName;
                if (Input.GetKey(KeyCode.E)&&timer <= 0f)
                {
                    
                    Debug.Log(levelToLoad);
                    timer = timeBetween;
                    SceneManager.LoadScene(levelToLoad);
                }
                else
                {
                    timer -= Time.deltaTime;
                }

            }
            else {

                myPlayer.interactText.text = "Purchase Game " + levelTextName + " for " + cost.ToString()  + " coins";
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log(PlayerPrefs.GetInt("coins"));
                    if (PlayerPrefs.GetInt("coins") >= cost)
                    {

                        unlocked = true;
                        PlayerPrefs.SetInt(levelTextName, 1);
                        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - cost);
                        myPlayer.coinsTxt.text = PlayerPrefs.GetInt("coins").ToString();
                        

                    }
                }
            }   
        }
       
    }
}
