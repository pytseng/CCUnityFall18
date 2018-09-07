using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLight : MonoBehaviour {
    //private float gapSize = 0.5f;

	void Start () {
        this.GetComponent<Light>().enabled = false;
    }

    void Update () {
        //if (this.transform.position.z >= Player.transform.position.z - gapSize &&
        //    this.transform.position.z <= Player.transform.position.z + gapSize &&
        //    this.transform.position.x >= Player.transform.position.x - gapSize &&
        //    this.transform.position.x <= Player.transform.position.x + gapSize)
        //{
            if (this.GetComponent<ProximityCheck>().CheckDistance()){
            Debug.Log("Entered zone");
            if(this.GetComponent<Light>().enabled == false){
                this.GetComponent<Light>().enabled = true;
            }
        }
        else {
            this.GetComponent<Light>().enabled = false;
        }

	}
}
