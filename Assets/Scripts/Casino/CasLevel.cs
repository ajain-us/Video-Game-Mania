using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;



public class CasLevel : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinsTxt;
    public int betAmount;

    private bool coinSide;
    public Sprite[] coinsSideA;
    public Image coin;
    public Image betCoin;

    public TextMeshProUGUI actionText;
    public TextMeshProUGUI betAmountText;

    public Slider numGame;
    public TextMeshProUGUI numGameText;
    public TextMeshProUGUI sliderText;


    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsTxt.text = "You have " + coins + " coins!";
        actionText.text = "You have not bet anything!";
        coinSide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(betAmount >= coins)
        {
            betAmount = coins;
        }else if(betAmount <= 0){
            betAmount = 1;
        }

        coinsTxt.text = "You have " + coins + " coins!";
        betAmountText.text = "You are currently betting " + betAmount + " coins!";

        sliderText.text = "The current value is: " + numGame.value;
    }

    public void increaseBet()
    {
        betAmount += 1;
    }

    public void decreaseBet()
    {
        betAmount -= 1;
    }

    public void coinFlip()
    {
        if (coins > 0)
        {
            coins -= betAmount;
            bool head = false;
            betCoin.sprite = coinsSideA[1];
            int temp = (int)Random.Range(0, 2);
            if (temp == 1)
            {
                head = true;
                betCoin.sprite = coinsSideA[0];
            }

            if (head == coinSide)
            {

                actionText.text = "You have won the game! coins won: " + betAmount * 2;
                coins += 2 * betAmount;
            }
            else
            {
                actionText.text = "You have lost the game! coins lost: " + betAmount;
            }
        }
        else
        {
            actionText.text = "You have no coins!";
        }
        
    }

    public void ChangeCoin()
    {
        coinSide = !coinSide;
        if (coinSide)
        {
            coin.sprite = coinsSideA[0];
        }
        else
        {
            coin.sprite = coinsSideA[1];
        }
    }

    public void returnLoser()
    {
        PlayerPrefs.SetInt("coins", coins);
        Debug.Log(PlayerPrefs.GetInt("coins"));

        SceneManager.LoadScene("Main");
    }

    public void NumberGuess()
    {
        if(coins > 0)
        {
            coins -= betAmount;
            int num = (int)Random.Range(0, 101);
            numGameText.text = "The number is " + num;
            if(num == (int)numGame.value)
            {
                coins += 50 * betAmount;
                actionText.text = "You have won the game! coins won: " + betAmount*50;

            }
            else
            {
                actionText.text = "You have lost the game! coins lost: " + betAmount;

            }

        }
        else
        {
            actionText.text = "You have no coins!";

        }
    }
     
}
