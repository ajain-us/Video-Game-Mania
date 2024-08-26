using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRB;
    public float destroyAfterEnd;
    public GameObject target;
    public LevelManager score;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        score = FindObjectOfType<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed);
        
        destroyAfterEnd -= Time.deltaTime;
        if(destroyAfterEnd < 0f) { Destroy(gameObject); }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "rock")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            score.score += 50;
            score.scoreSpawn += 50;
        }
    }

}
