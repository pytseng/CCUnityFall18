using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
    Vector3 moveVelocity;
    Vector3 startPos;
    public bool RunFall;

	// Use this for initialization
	void Start () {
        if (RunFall)
        {
            startPos = this.transform.localPosition;
            moveVelocity = new Vector3(0f, Random.Range(-2f, -4f), 0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (RunFall)
        {
            this.GetComponent<Rigidbody>().velocity = moveVelocity;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (RunFall)
        {
            if (collision.gameObject.tag != "Generated")
            {
                this.transform.localPosition = startPos;

            }
        }
    }
}
