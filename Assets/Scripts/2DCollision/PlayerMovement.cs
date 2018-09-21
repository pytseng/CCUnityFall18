using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float speed = 1f;
    float jumpForce = 500f;
    float score;
    Vector2 scale;

    void Start () {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        scale = new Vector2(0.24f, 0.24f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.Space)){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);

        }
	}

    private void OnCollisionExit(Collision collision)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Character")){
            //if(collision.gameObject.layer == LayerMask.NameToLayer("Character"))
            Destroy(collision.gameObject);
            scale *= 2f;
            this.transform.localScale = scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Environment")){
            SceneManager.LoadScene("Week4");
        }

    }
}
