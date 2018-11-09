using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDivision : MonoBehaviour {
    [SerializeField] GameObject plane;
    GameObject[] divider;
    int sizeOfArray = 6;

	void Start () {
        divider = new GameObject[sizeOfArray];
        for (int i = 0; i < sizeOfArray; i++){
            divider[i] = Instantiate(plane);
            divider[i].transform.position = new Vector3(-25 + i * 10, 0, 20);
            divider[i].GetComponent<MeshRenderer>().materials[0].color = new Color(i * (1f / (sizeOfArray - 1)), i * (1f / (sizeOfArray -1)), i * (1f/(sizeOfArray -1)));
                //i / (size of array - 1) * color.r g b
        }
        divider[3].GetComponent<NPCMovement>().oscil = true;
        divider[5].GetComponent<NPCMovement>().oscil = true;
	}
}
