using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Character")){
            Debug.Log("Hi there, character");
        } else if (collision.gameObject.CompareTag("Environment")){
            Debug.Log("Collided with ground");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");   
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("Still Colliding");
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("Collisin ended");
    //}
}
