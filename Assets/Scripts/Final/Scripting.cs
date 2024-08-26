using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripting : MonoBehaviour
{
    public GameObject spawningItems;
    public float timeBetween;
    private float timer;
    public float xMin;
    public float xMax;
    private float xPos;
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = Random.Range(xMin, xMax);

        if(timer > 0)
        {
            timer-= Time.deltaTime;
        }
        else
        {
            Instantiate(spawningItems, new Vector3(xPos, height, 0f), Quaternion.identity);
            timer = timeBetween;
        }
    }
}
