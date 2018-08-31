using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {
    Color myColor = new Color(0f, 0.6f, 0.8f);
    Vector3 pos;
	// Use this for initialization
	void Start () {
        //Debug.Log(this.transform.localPosition);
        pos = this.transform.position;

    }

    // Update is called once per frame
    void Update () {
        Debug.Log("This is my repeated message");
        //pos = this.transform.position;
        pos.x += 0.1f;
        pos.y -= 0.2f;
        pos.z += 0.05f;
        this.transform.position = pos;
        Debug.Log(this.transform.position);
        myColor = new Color(pos.x, pos.y, pos.z);
        this.GetComponent<MeshRenderer>().materials[0].color = myColor;


    }

    private void LateUpdate()
    {
        //Debug.Log("This will print last");
    }

    private void FixedUpdate()
    {
        //Debug.Log("This will print at a fixed time interval");
    }
}
