using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRotation : MonoBehaviour {
    [SerializeField] Vector3 eulerDelta;
    [SerializeField] float rotateDuration = 5f;
    [SerializeField] bool additive;

	void Start () {
        //eulerDelta = new Vector3(30, 75, 15);
        if (additive)
        {
            StartCoroutine(Rotation(this.transform.rotation, this.transform.rotation * Quaternion.Euler(eulerDelta), rotateDuration));
        } else {
            StartCoroutine(Rotation(this.transform.rotation, Quaternion.Euler(eulerDelta), rotateDuration));

        }
    }

    private void Update()
    {
        //if (this.transform.position.x > 10f)
        //{
        //    StartCoroutine(Rotation(this.transform.rotation, Quaternion.Euler(eulerDelta), rotateDuration));
        //}
    }

    IEnumerator Rotation(Quaternion start, Quaternion end, float duration){
        float endTime = Time.time + duration;
        Debug.Log("Coroutine started");
        while (this.transform.rotation != end){
            float interpolant = 1f - (endTime - Time.time) / duration;
            transform.rotation = Quaternion.Slerp(start, end, interpolant);
            //Debug.Log("While Loop in progress");
            yield return null;
        }
        Debug.Log("rotation has ended");
        yield return new WaitForSeconds(3f);
        Debug.Log("Coroutine Ended");

        StartCoroutine(Rotation(this.transform.rotation, Quaternion.Euler(eulerDelta * Random.Range(0.5f, 2f)), rotateDuration));

    }
}
