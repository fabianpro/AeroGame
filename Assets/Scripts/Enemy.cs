using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Obj;
    public GameObject StartBulletLeft;
    public GameObject StartBulletRight;
    public GameObject StartBomb;
    public GameObject NuclearBomb;
    public GameObject BulletPrefab;    
    public float TimeCreate;
    public float velocityBullet;
    public AudioSource ShootingAudio;
    
    private float TimeElapsed;    

    // Update is called once per frame
    void Update()
    {        
        if (TimeElapsed <= 0) {
            TimeElapsed = TimeCreate;
            int objPosition = Random.Range(-3, 4);            
            GameObject objTmp = Instantiate(Obj, new Vector3(objPosition, 11, 0), Quaternion.identity);            
            Destroy(objTmp, 5);
        }

        TimeElapsed -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && GameObject.Find("Player") != null) {          
            ShootingAudio.Play();
            GameObject bulletTmpLeft = Instantiate(BulletPrefab, StartBulletLeft.transform.position, StartBulletLeft.transform.rotation);
            GameObject bulletTmpRight = Instantiate(BulletPrefab, StartBulletRight.transform.position, StartBulletRight.transform.rotation);
            Rigidbody rigidbodyTmpLeft = bulletTmpLeft.GetComponent<Rigidbody>();
            Rigidbody rigidbodyTmpRight = bulletTmpRight.GetComponent<Rigidbody>();
            rigidbodyTmpLeft.AddForce(transform.up * velocityBullet);
            rigidbodyTmpRight.AddForce(transform.up * velocityBullet);
            Destroy(rigidbodyTmpLeft, 5.0f);
            Destroy(rigidbodyTmpRight, 5.0f);                       
        }

        if (Input.GetMouseButtonDown(1) && GameObject.Find("Player") != null) {
            ShootingAudio.Play();
            GameObject nuclearBomb = Instantiate(NuclearBomb, StartBomb.transform.position, StartBomb.transform.rotation);
            Rigidbody rigidbodyTmp = nuclearBomb.GetComponent<Rigidbody>();
            rigidbodyTmp.AddForce(transform.up * 1200f);
            Destroy(rigidbodyTmp, 5.0f);        
        }
    }    
}
