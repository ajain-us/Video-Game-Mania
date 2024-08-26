using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    private bool left;
    public float moveSpeed;
    public float jumpSpeed;
    private float xSPeed;
    private float ySPeed;
    private LevelManFinal lives;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        lives = FindObjectOfType<LevelManFinal>();
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
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            xSPeed = moveSpeed;

            left = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ySPeed = jumpSpeed;
        }

        myRB.velocity = new Vector3(xSPeed, ySPeed, 0f);
        xSPeed= 0f;
        ySPeed= 0f;

        if (left)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "projectile") 
        {
            Destroy(other.gameObject);
            lives.removeLife();
        
        }
    }
}
