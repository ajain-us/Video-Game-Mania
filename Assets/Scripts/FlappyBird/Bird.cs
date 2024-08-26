using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Rigidbody2D myRb;
    public float upSpeed;
    private LevelManagerFlap flap;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        flap = FindObjectOfType<LevelManagerFlap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRb.velocity = new Vector3(0f,upSpeed, 0f);
        }

        if(transform.position.y < -5 || transform.position.y > 5)
        {
            flap.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ok?1");
        if (other.gameObject.tag == "rock") { flap.GameOver(); }
        if (other.gameObject.tag == "Fuel"){
            //Destroy(other.gameObject);
            Debug.Log("ok?");
            flap.score = flap.score + 1;}
    }

    
}
