using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassbyCheck : MonoBehaviour
{
    public GameObject Target;
    private float gapSize = 2f;
    private float passByX = 10f;
    //bool collided = false;

    public bool CheckDistance()
    {
        if (Mathf.Abs(this.transform.position.z - Target.transform.position.z) <= gapSize &&
            Mathf.Abs(this.transform.position.x - Target.transform.position.x) <= passByX)
        {
            //collided = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
