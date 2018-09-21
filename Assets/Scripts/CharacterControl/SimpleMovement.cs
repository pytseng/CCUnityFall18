using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {
    public float speed = 0.1f;
    private Vector3 pos;
	void Start () {
        pos = this.transform.position;
	}
	
	void Update () {
        if(Input.GetKey(KeyCode.UpArrow)){
            DrawIt(Vector3.forward);
            pos.z += speed;
        }else if (Input.GetKey(KeyCode.DownArrow)){
            DrawIt(Vector3.down);
            pos.z -= speed;
        }else if (Input.GetKey(KeyCode.LeftArrow)){
            DrawIt(Vector3.left);
            pos.x -= speed;
        }else if (Input.GetKey(KeyCode.RightArrow)){
            DrawIt(Vector3.right);
            pos.x += speed;
        }
        this.transform.position = pos;
	}

    void DrawIt (Vector3 vec){
        Debug.DrawRay(pos, vec*100, Color.yellow); 
        // the ray is short, so I magnified it a bit.
        Debug.DrawRay(pos, vec * speed, Color.red);
    }
}
