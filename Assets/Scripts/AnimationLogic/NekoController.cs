using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoController : MonoBehaviour {
    float velX;
    float velY;
    Animator myAnim;
    Rigidbody rb;

	void Start () {
        myAnim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
	}
	
	void Update () {
        if(Time.time >= 3f && Time.time <= 3.1f){
            myAnim.Play("WhiteCat");
        }

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");

        myAnim.SetFloat("VelX", velX);
        myAnim.SetFloat("VelY", velY);
	}

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velX, velY, 0f);
    }
}
