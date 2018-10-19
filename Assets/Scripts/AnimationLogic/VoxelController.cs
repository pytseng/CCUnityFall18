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
    float motion1;
    float motion2;
    bool loseStart;
    bool deathStart;
	void Start () {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        evt = new AnimationEvent();
        evt.functionName = "FinishJump";
	}
	
	void Update () {
        WalkLogic();
        JumpLogic();
        BlendStates();
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

    void BlendStates(){
        motion1 = Input.GetAxis("Vertical");
        motion2 = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            loseStart = true;
        } else {
            loseStart = false;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            deathStart = true;
        } else {
            deathStart = false;
        }
        anim.SetFloat("Death", motion1);
        anim.SetFloat("Lose", motion2);
        anim.SetBool("DeathStart", deathStart);
        anim.SetBool("LoseStart", loseStart);
    }
}
