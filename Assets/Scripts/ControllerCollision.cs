using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollision : MonoBehaviour
{   

    public AudioSource Burst;

    private void OnTriggerEnter(Collider other) {        
        if (other.gameObject.tag == "Bullet") {
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().AddPoint();
            Burst.Play();
        } 
        
        /*
        Reduce scale if is collisioned
        else {
            this.gameObject.transform.localScale = new Vector3(
                this.gameObject.transform.localScale.x * 0.5f, 
                this.gameObject.transform.localScale.y * 0.5f, 
                this.gameObject.transform.localScale.z * 0.5f
            );
        }*/
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);  
        FindObjectOfType<GameManager>().EndGame();               
    }    
}
