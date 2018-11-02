using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRain : MonoBehaviour {
    [SerializeField] GameObject rain;
    GameObject[] rainObjectSet = new GameObject[50];
    int numRainDrops = 50;
    Vector3 startingPos;
    public bool RunRain;

    private void Awake()
    {
        this.enabled = false;
    }
    void OnEnable()
    {
        for (int i = 0; i < numRainDrops; i++)
        {
            startingPos = new Vector3(Random.Range(-30f, 30f), 10, -10);
            rainObjectSet[i] = Instantiate(rain, this.transform) as GameObject;
        }
    }
}
