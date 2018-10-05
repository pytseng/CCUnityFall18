using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;
    public int x=5, y=5, z=5;

    public float speed;

    void Start()
    {
        Debug.Log("entered");
        // add isTrigger
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Debug.Log("potato");

            }
        }


            // Follows the target position like with a spring
            void Update()
    {
        Debug.Log("moving");
        float horizontal = Input.GetAxisRaw("Horizontal")*10;
        float vertical = Input.GetAxisRaw("Vertical")*10;

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.left * speed*10 * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(-Vector3.left * speed*10 * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.up * speed * 10 * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
          transform.Rotate(-Vector3.up * speed * 10 * Time.deltaTime);


        Vector3 direction = new Vector3(horizontal, 0, vertical);

        gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);


    }

   
}