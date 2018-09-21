using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
    Vector2 initialPos;
    Vector2 pos;
    float theta;
    float rateOfIncrease;
    float amplitude;

    [SerializeField] bool rotate;
    [SerializeField] bool oscil;

    // Use this for initialization
    void Start () {
        //random range x: 0 45, y: 0 to 17

        initialPos.x = Random.Range(0, 45);
        initialPos.y = Random.Range(0, 17);
        this.transform.position = initialPos;

        pos = this.transform.position;

        rateOfIncrease = Random.Range(0.005f, 0.2f);
        amplitude = Random.Range(2, 5);
    }
	
	// Update is called once per frame
	void Update () {
        if(oscil){
            Oscillate();
        } else if (rotate){
            TrigRotate();
        }
	}

    void Oscillate()
    {
        //y = sine of the theta, x increases over time, theta increases over time
        pos.y = Mathf.Sin(theta) * amplitude;
        pos.x += 0.01f;
        theta += rateOfIncrease;
        transform.position = pos;
    }

    void TrigRotate()
    {
        pos.y = Mathf.Sin(theta) * amplitude + initialPos.y;
        pos.x = Mathf.Cos(theta) * amplitude + initialPos.x;
        theta += rateOfIncrease;
        transform.position = pos;
    }
}
