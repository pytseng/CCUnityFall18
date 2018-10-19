using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoController : MonoBehaviour {
    float velX;
    float velY;
    float lastX;
    float lastY;
    Animator myAnim;
    bool moving;
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
        myAnim.SetBool("Moving", moving);
        IdleCheck();
	}

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velX, velY, 0f);
    }

    void IdleCheck(){
        if (velX > 0.01 || velX < -0.01 || velY >0.01 || velY < -0.01){
            moving = true;
            lastX = velX;
            lastY = velY;
            myAnim.SetFloat("LastX", lastX);
            myAnim.SetFloat("LastY", lastY);
        } else {
            moving = false;
        }
    }
}
