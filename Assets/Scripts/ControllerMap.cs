using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMap : MonoBehaviour
{   
    public GameObject Sky;

    private string Rotate;

    private void Start() {
        Invoke("RotateSky", 1);        
    }
    
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetAxis("Mouse X") < 0)
        {
            Rotate = "left";
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            Rotate = "right";
        }
        else {
            Rotate = "none";
        }
        Invoke("RotateSky", 1);
    }

    void RotateSky () 
    {
        //float xAngle = Random.Range(-0.04f, 0.04f);        
        float yAngle = Rotate == "right" ? -0.1f : Rotate == "left" ? 0.1f : 0.0f;
        Sky.transform.Rotate(0.03f, yAngle, 0.0f, Space.Self);
    } 
}
