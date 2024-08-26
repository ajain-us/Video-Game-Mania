using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;



public class Maze : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float moveSpeed;
    

    private float xSPeed;
    private float ySPeed;
    private float topRot;

    public LevelManagerMaze scoreOrg;




    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        scoreOrg = FindObjectOfType<LevelManagerMaze>();
            
        

}

// Update is called once per frame
void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            xSPeed = -moveSpeed;
            topRot = 270;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            xSPeed = moveSpeed;
            topRot = 90;



        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            ySPeed = moveSpeed;
            myRB.velocity = new Vector3(0f, moveSpeed, 0f);
            topRot = 180;

        }
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            ySPeed = -moveSpeed;
            topRot = 0;


        }

        myRB.velocity = new Vector3(xSPeed, ySPeed, 0f);
        xSPeed = 0f;
        ySPeed = 0f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, topRot));

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Fuel")
        {
            scoreOrg.addTime();
            Destroy(other.gameObject);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(2, -1);
    }
}
