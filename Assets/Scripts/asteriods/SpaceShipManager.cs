using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float rotSpeed;
    public GameObject pew;
    public Transform position;
    public LevelManager lives;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        position = transform;
        lives = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            myRB.rotation += rotSpeed;
        }else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myRB.rotation -= rotSpeed;
        }
        
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pew,transform.position,transform.rotation);
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "rock")
        {
            Destroy(other.gameObject);
            lives.lives -= 1;
        }
    }
}
