using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBuiltinRotations : MonoBehaviour {
    Vector3 rotateEuler;
    //Vector3 targetRotation;
    Quaternion targetRotation;
    float xAngle;
    float yAngle;
    float zAngle;
	// Use this for initialization
	void Start () {
        rotateEuler = new Vector3(3, 0, 0);

        targetRotation = Quaternion.Euler(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        ////if transform x axis is less than 90 degrees
        //if(this.transform.rotation < targetRotation)
        //{
        //this.transform.Rotate(rotateEuler);
        //}
        RotateManually();
	}

void RotateManually(){
        //if rotate on pitch;
        xAngle += 1;
        //if rotate on yaw;
        yAngle += 1;
        //if rotate on roll;
        zAngle += 1;

        transform.localRotation = Quaternion.Euler(xAngle, yAngle, zAngle);
}



}
