using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintToScreen : MonoBehaviour {

    Color myColor = new Color(1f, 0.5f, 0.5f);
    public Color MyOtherColor;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Hello World";
        GetComponent<Text>().color = MyOtherColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
