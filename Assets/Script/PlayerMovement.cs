using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 22f;
    public float gravity = -50.81f;
    public Transform groungcheck;
    public float grounddis = 0.4f;
    public float jump = 6f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGround;
    void Start()
    {
        
    }
    void Update()
    {
        isGround = Physics.CheckSphere(groungcheck.position, grounddis, groundMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move*speed*Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
