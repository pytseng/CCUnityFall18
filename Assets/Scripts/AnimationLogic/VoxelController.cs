using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelController : MonoBehaviour {
    float vel;
    Animator anim;
    Rigidbody rb;
    AnimationEvent evt;

    bool jumpStarted;
    bool jumpEnded = true;
    bool startReturnToZero;

	void Start () {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        evt = new AnimationEvent();
        evt.functionName = "FinishJump";
	}
	
	void Update () {
        WalkLogic();
        JumpLogic();
	}

    void WalkLogic(){
        if(Input.GetKey(KeyCode.I)){
            vel = Mathf.Lerp(vel, -1, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.K)){
            vel = Mathf.Lerp(vel, 1, Time.deltaTime);
        }
        if((Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.K))){
            startReturnToZero = true;
        }
        if (startReturnToZero)
        {
            vel = Mathf.Lerp(vel, 0, Time.deltaTime * 3f);
        }
        if(vel >= -0.01f && vel <=0.01f){
            startReturnToZero = false;
        }
        anim.SetFloat("WalkVel", vel);
    }

    void JumpLogic(){
        if (Input.GetKey(KeyCode.Space) && jumpEnded == true){
            jumpStarted = true;
            jumpEnded = false;
        }
        anim.SetBool("JumpStart", jumpStarted);
        jumpStarted = false;

    }
    public void FinishedJump(){
        jumpEnded = true;
    }
}
