using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderRight : MonoBehaviour
{
    public float move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Line")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x + move, other.gameObject.transform.position.y, 0f);
        }
    }
}
