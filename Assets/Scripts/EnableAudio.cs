using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAudio : MonoBehaviour {
    //private float gapSize = 0.5f;
	void Start () {
        this.GetComponent<AudioSource>().pitch = 2f;
	}

    void Update()
    {
        //if (this.transform.position.z >= Player.transform.position.z - gapSize &&
        //    this.transform.position.z <= Player.transform.position.z + gapSize &&
        //    this.transform.position.x >= Player.transform.position.x - gapSize &&
        //    this.transform.position.x <= Player.transform.position.x + gapSize)
        //{
        if (this.GetComponent<ProximityCheck>().CheckDistance() == true){
            if(this.GetComponent<AudioSource>().isPlaying == false){
                this.GetComponent<AudioSource>().Play();
            }

        }
    }
}
