using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class hand : MonoBehaviour
{
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition.y);
        //Debug.Log(Input.mousePosition.y)
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if ((Math.Abs(Input.mousePosition.x) < Screen.width && Input.mousePosition.x >0) && (Math.Abs(Input.mousePosition.y) < Screen.height && Input.mousePosition.y > 0))
        {
            transform.position = mousePos;
        }
        else
        {
            //transform.position = new Vector3(0, 0, 0);


        }

    }
}
