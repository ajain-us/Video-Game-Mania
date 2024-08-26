using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRb;


    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myRb.velocity = new Vector3(moveSpeed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -10)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
