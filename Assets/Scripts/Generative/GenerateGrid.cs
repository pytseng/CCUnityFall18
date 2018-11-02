using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour {

    int columns = 6;
    int rows = 4;
    int depth = 5;
    int numOfCubes;
    int offset = 10;
    float speedOfIteration = 2;
    public bool RunGrid;

    [SerializeField] GameObject cube;
    GameObject[] cubeSystem;

    private void Awake()
    {
        this.enabled = false;
    }
    void OnEnable () {
            numOfCubes = columns * rows * depth;
            cubeSystem = new GameObject[numOfCubes];
            //i want 6 columns, 4 rows
            //0  1  2  3  4  5
            //6  7  8  9  10 11
            //12 13 14 15 16 17
            //18 19 20 21 22 23

            for (int i = 0; i < numOfCubes; i++)
            {

                float xPos = (i % columns) * offset;
                float yPos = (Mathf.Floor(i / columns) % rows) * offset;
                //math.floor(i / (rows * cols))
                float zPos = Mathf.Floor(i / (rows * columns)) * offset;
                Vector3 cubePos = new Vector3(xPos, yPos, zPos);
                cubeSystem[i] = Instantiate(cube, this.transform) as GameObject;
                cubeSystem[i].transform.localPosition = cubePos;
            }
    }

    void Update()
    {
            float iteration = (Mathf.Floor(Time.time * speedOfIteration)) % numOfCubes;
            // each second one cube grows in scale
            // next second, the next cube grows in scale
            for (int i = 0; i < numOfCubes; i++)
            {
                if (iteration == i)
                {
                    cubeSystem[i].transform.localScale = new Vector3(4 * (Time.time * speedOfIteration - iteration), 4 * (Time.time * speedOfIteration - iteration), 4 * (Time.time * speedOfIteration - iteration));
                }
                else
                {
                    cubeSystem[i].transform.localScale = Vector3.one;
                }
        }
    }
}
