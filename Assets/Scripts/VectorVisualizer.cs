using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorVisualizer : MonoBehaviour {
    Vector3 vecA;
    Vector3 vecB;
    float mag;
    Vector3 normalA;

	void Start () {
        vecA = new Vector3(3, 6, 9);
        vecB = new Vector3(-2, 2, 8);
	}
	
	// Update is called once per frame
	void Update () {
        //DrawVectorMath();
        DrawTransformVectors();
    }

    void DrawVectorMath(){
        Debug.DrawRay(Vector3.zero, vecA, Color.blue);
        Debug.DrawRay(Vector3.zero, vecB, Color.red);
        //magnitude = sqrt(x^2 + y^2 + z^2)
        mag = Mathf.Sqrt(vecA.x * vecA.x + vecA.y * vecA.y + vecA.z * vecA.z);
        //Mathf.Pow(vecA.x, 2f)

        Debug.Log("mag: " + mag); //;print();
        Debug.Log("this is Unity mag: " + vecA.magnitude);
        //print("mag" + mag);

        //normal vector = yourVector / magnitude
        normalA = vecA / mag;
        Debug.Log("normal: " + normalA);
        Debug.Log("Unity built in normal: " + vecA.normalized);
        //Debug.DrawRay(Vector3.zero, normalA * 20f);
        Debug.DrawRay(Vector3.zero, normalA, Color.green);

        //Addition
        Debug.DrawRay(Vector3.zero, vecA + vecB, Color.gray);

        //Subtraction
        Vector3 AMinusB = vecA - vecB;
        Vector3 BMinusA = vecB - vecA;

        Debug.DrawRay(vecA, BMinusA, Color.yellow);
        Debug.DrawRay(vecB, AMinusB, Color.magenta);
    }

    void DrawTransformVectors(){
        Debug.DrawRay(transform.position, transform.right, Color.green);
        Debug.DrawRay(transform.position, transform.up, Color.red);
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
    }
}
