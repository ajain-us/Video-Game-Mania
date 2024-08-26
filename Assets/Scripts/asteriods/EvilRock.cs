using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRock : MonoBehaviour
{
    public float moveSpeed;
    public SpaceShipManager ship;
    public LevelManager des;



    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<SpaceShipManager>();
        des = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f) {
            transform.position = Vector3.MoveTowards(transform.position, ship.position.position, moveSpeed); }


        if((transform.position.x == 0 && transform.position.y == 0)||des.lives<=0)
        {
            Destroy(gameObject);
        }

    }
}
