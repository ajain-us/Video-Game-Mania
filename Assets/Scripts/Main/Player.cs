using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRB;
    public TextMeshProUGUI coinsTxt;
    

    public float moveSpeed;
    private SpriteRenderer mySR;

    public TextMeshProUGUI interactText;

  
    private bool left;
    private float xSPeed;
    private float ySPeed;

    public Vector3[] newCam;
    public Camera cam;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        cam = Camera.main;

        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
        if(PlayerPrefs.HasKey("coins") == false)
        {
            PlayerPrefs.SetInt("coins", 1);
        }
        coinsTxt.text = PlayerPrefs.GetInt("coins").ToString();
        interactText.enabled = false;
        anim = GetComponent<Animator>();
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            xSPeed = -moveSpeed;
            left = true;

            

        }
         if(Input.GetAxisRaw("Horizontal") > 0)
        {
            xSPeed = moveSpeed;
            
            left = false;


        }
         if(Input.GetAxisRaw("Vertical") > 0)
        {
            ySPeed = moveSpeed;
            myRB.velocity = new Vector3(0f, moveSpeed, 0f);
            
        }
         if (Input.GetAxisRaw("Vertical") < 0f)
        {
            ySPeed = -moveSpeed;
            
            
        }

        myRB.velocity = new Vector3(xSPeed, ySPeed, 0f);
        anim.SetFloat("Speed", Math.Abs(xSPeed) + Math.Abs(ySPeed));
        xSPeed = 0f;
        ySPeed = 0f;

        if (left)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }

        if(transform.position.y > 5.5f)
        {
            cam.transform.position = newCam[0];
        }else if (transform.position.y < -5.5)
        {
            cam.transform.position = newCam[1];
        }else if(transform.position.x > 9.5)
        {
            cam.transform.position = newCam[2];
        }
        else
        {
            cam.transform.position = newCam[3];
        }

        
        



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GameMachine")
        {
            interactText.enabled = true;
            
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "GameMachine")
        {
            interactText.enabled = false; 
            
        }
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("Start") == false)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Start", 0);
        }
        else
        {

        }
        

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Start");
    }

}
