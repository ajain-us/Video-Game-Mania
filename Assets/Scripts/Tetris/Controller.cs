using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject controlling;
    private float rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            controlling.transform.position = new Vector3(controlling.transform.position.x - 1f, controlling.transform.position.y, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            controlling.transform.position = new Vector3(controlling.transform.position.x + 1f, controlling.transform.position.y, 0f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rotate += 90;
            controlling.transform.rotation = Quaternion.Euler(0, 0, rotate);
        }
    }
}
