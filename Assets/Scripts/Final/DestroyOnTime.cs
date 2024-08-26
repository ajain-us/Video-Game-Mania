using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
