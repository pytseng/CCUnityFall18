using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDropObject : MonoBehaviour {
    public GameObject dropObject;
    public GameObject mainObject;
    public float speed = 0.1f;
    public Vector3 moveForce;


    // Use this for initialization
    void Start () {
		
	}

    void OnCollisionEnter(Collision collidingObject)
    {

        if (collidingObject.gameObject.name == "Dish"){
            StartCoroutine("DropIt");
            dropObject.GetComponent<AudioSource>().enabled = true;
            if (dropObject.GetComponent<AudioSource>().isPlaying == false)
            {
                dropObject.GetComponent<AudioSource>().Play();
            }
        }

            
    }
    System.Collections.IEnumerator DropIt()
    {


        while (Vector3.Distance(dropObject.transform.position, mainObject.transform.position) > 1f)
        {
            yield return new WaitForEndOfFrame();
            float step = speed * Time.deltaTime;
            var heading = mainObject.transform.position - dropObject.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            Debug.DrawRay(dropObject.transform.position, heading, Color.white);
            Debug.DrawRay(dropObject.transform.position, direction, Color.magenta);
            dropObject.transform.position = Vector3.MoveTowards(dropObject.transform.position, mainObject.transform.position, speed);
            Debug.Log("distance" + Vector3.Distance(dropObject.transform.position, mainObject.transform.position) );
            //dropObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

            if (Vector3.Distance(dropObject.transform.position, mainObject.transform.position) < 1f)
            {
                if (dropObject.GetComponent<Rigidbody>() != null)
                {
                    dropObject.transform.position = mainObject.transform.position + Vector3.up/4f;
                    //mainObject.AddComponent<FixedJoint>();
                    //mainObject.GetComponent<FixedJoint>().connectedBody = dropObject.GetComponent<Rigidbody>();
                    dropObject.transform.parent = mainObject.transform;
                    dropObject.GetComponent<Collider>().enabled = false;
                }
                break;
            }
        }
        //Debug.Log("bamg");
        yield return null;
        //while ( Vector3.Distance(dropObject.transform.position, mainObject.transform.position) > 0.3f)
        //{
        //    float step = speed;
        //    dropObject.transform.position = Vector3.MoveTowards(dropObject.transform.position, mainObject.transform.position, step);
        //    yield return null;
        //}

    }
    //void DropIt2 (){
    //    dropObject.transform.position = Vector3.MoveTowards(dropObject.transform.position, mainObject.transform.position, step);

    //}

}
