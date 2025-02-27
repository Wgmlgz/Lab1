using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Vector3 jumpForce = new(0, 300, 0);
    public Vector3 gravityForce = new(0, -10, 0);

    public Collider wallTrigger;
    public Transform cam;

    bool touchingWall = false;

    public int airMaxJumps = 1;
    int jumpsLeft = 0;

    public float speed = 300;

    Vector3 input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        var isSpace = Input.GetKeyDown(KeyCode.Space);

        // Reset jumps when on ground
        if (IsGrounded()) jumpsLeft = airMaxJumps;

        // Ground and air jump
        if (isSpace && jumpsLeft > 0)
        {
            if (!IsGrounded())
                jumpsLeft -= 1;
            Jump();
        }

        if (isSpace && touchingWall)
        {
            Jump();
        }
    }

    void CancelVerticalVelocity()
    {
        var tmp = rigidBody.linearVelocity;
        tmp.y = 0;
        rigidBody.linearVelocity = tmp;
    }
    void Jump()
    {
        CancelVerticalVelocity();
        rigidBody.AddForce(jumpForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.AddForce(Time.fixedDeltaTime * gravityForce);

        input.x = 0;
        input.z = 0;

        var sus = transform.position + (transform.position - cam.position);
        sus.y = transform.position.y;
        transform.LookAt(sus);


        if (Input.GetKey(KeyCode.A))
            input -= transform.right;
        if (Input.GetKey(KeyCode.D))
            input += transform.right;

        if (Input.GetKey(KeyCode.W))
            input += transform.forward;
        if (Input.GetKey(KeyCode.S))
            input -= transform.forward;

        input = Vector3.Normalize(input) * speed;

        // Vector3 speed = rigidBody.linearVelocity;
        var aa = input * Time.fixedDeltaTime;
        // rigidBody.position += input * Time.fixedDeltaTime;
        rigidBody.linearVelocity = new(
            // Math.Abs(input.x) < 0.1 && !IsGrounded() ?
            // rigidBody.linearVelocity.x : 
            aa.x,
            rigidBody.linearVelocity.y,
              // Math.Abs(input.z) < 0.1 && !IsGrounded() ?
              //  rigidBody.linearVelocity.z :
              aa.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            jumpsLeft = airMaxJumps;
        }
    }

    void OnTriggerExit(Collider other)
    {
    }

    private bool IsGrounded()
    {
        //Simple way to check for ground
        if (Physics.Raycast(transform.position, Vector3.down, 1.01f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
