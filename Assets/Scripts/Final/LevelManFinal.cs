using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class LevelManFinal : MonoBehaviour
{
    public TextMeshProUGUI secondsTime;
    public float timeTillRelease;
    public string victory;
    public float lives;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillRelease > 0)
        {
            secondsTime.text = "Survive for: "+ (int)timeTillRelease + " seconds";
            timeTillRelease -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(victory);
        }
        livesText.text = "Lives: " + lives;
    }

    public void removeLife()
    {
        if(lives <= 1)
        {
            SceneManager.LoadScene("Final");
        }
        else
        {
            lives -= 1;
        }
    }
}
