using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D shipRb;
    public float moveSpeed;

    private bool isMoving = false;
    private bool isTurning = false;

    private float horizontalInput;
    public float turnSpeed;

    //public ParticleSystem thrusters;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        //print(horizontalInput);

        if (horizontalInput != 0)
        {
            isTurning = true;
        }
        else
        {
            isTurning = false;
        }
    }

    private void FixedUpdate()
    {
        if(isMoving == true)
        {
            Move();
        }

        if(isTurning == true)
        {
            TurnShip();
        }
    }

    void Move()
    {
        //thrusters.Play();

        shipRb.AddForce(transform.up * moveSpeed);
    }

    void TurnShip()
    {
        shipRb.AddTorque(-horizontalInput * turnSpeed);
    }

    /*void StopMoving()
    {
        shipRb.velocity = Vector2.zero;
        shipRb.angularVelocity = 0.0f;
    }
    */
}
