using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFunctions : MonoBehaviour {
    Vector2 initialPos;
    Vector2 pos;

    float theta;
    [SerializeField] private float amplitude = 5f;
    [SerializeField] private float rateOfIncrease = 0.05f;
	// Use this for initialization
	void Start () {
        initialPos = Random.insideUnitCircle;
        initialPos.x *= 8;
        initialPos.y *= 4;
        this.transform.position = initialPos;

        pos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Oscillate();
       //TrigRotate();
	}

    void Oscillate(){
        //y = sine of the theta, x increases over time, theta increases over time
        pos.y = Mathf.Sin(theta) * amplitude;
        pos.x += 0.01f;
        theta += rateOfIncrease;
        transform.position = pos;
    }

    void TrigRotate(){
        pos.y = Mathf.Sin(theta) * amplitude;
        pos.x = Mathf.Cos(theta) * amplitude;
        theta += rateOfIncrease;
        transform.position = pos;
    }
}
