using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMode : MonoBehaviour {
    public enum Mode
    {
        rain = 0,
        grid
    };

   public Mode myMode;

    int mode = 0; // if mode = 0, generate rain... if mode = 1 generate grid... if mode = 2 generate cats;

	void Update () {
        if(myMode == Mode.rain){
            GetComponent<GenerateRain>().enabled = true;
            //GetComponentInChildren<Falling>().RunFall = true;
            GetComponent<GenerateGrid>().enabled = false;
        }
        else if(myMode == Mode.grid){
            GetComponent<GenerateGrid>().enabled = true;
            GetComponent<GenerateRain>().enabled = false;
            //GetComponentInChildren<Falling>().RunFall = false;
        }
	}
}
