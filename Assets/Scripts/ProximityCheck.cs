using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour {
    public GameObject Target;
    private float gapSize = 0.5f;
    //bool collided = false;

    public bool CheckDistance()
    {
        if (this.transform.position.z >= Target.transform.position.z - gapSize &&
            this.transform.position.z <= Target.transform.position.z + gapSize &&
            this.transform.position.x >= Target.transform.position.x - gapSize &&
            this.transform.position.x <= Target.transform.position.x + gapSize)
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
