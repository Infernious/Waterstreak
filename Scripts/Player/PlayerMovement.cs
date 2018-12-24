using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float desiredRot;
    public float rotSpeed = 150f;
    public float damping = 10f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;

    Rigidbody rb;

    Vector3 moveDirection;

    bool onGround = false;
    bool jumpRequest;

    // Use this for initialization
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        rb = GetComponent<Rigidbody>();

        desiredRot = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

        Quaternion desiredRotQ = Quaternion.Euler(0, desiredRot, 0);

        if (Input.GetKey(KeyCode.A))
        {
            desiredRot -= rotSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            desiredRot += rotSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            //rb.velocity = transform.forward * moveSpeed;
            transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            //rb.velocity = -transform.forward * moveSpeed;
            transform.Translate(0f, 0f, -moveSpeed * Time.deltaTime);
        }

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpRequest = true;
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            jumpRequest = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            onGround = true;
        }

        else if (col.collider.tag == "platform")
        {
            onGround = true;
        }
    }

    void OnCollisionExit()
    {
        onGround = false;
    }
}