using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rb;

    private int speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started Game");        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            Rb.velocity = -transform.right * speed;
            transform.Rotate(0.0f, 0.2f, 0.0f, Space.Self);
            print("Mouse moved left");
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            Rb.velocity = transform.right * speed;
            transform.Rotate(0.0f, -0.2f, 0.0f, Space.Self);
            print("Mouse moved right");
        }
        else {
            //Rb.velocity = transform.right * speed;
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            print("Mouse moved center");
        }
    }
}
