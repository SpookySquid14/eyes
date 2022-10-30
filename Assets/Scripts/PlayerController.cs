using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //declaring variables
    Controls controls;
    [SerializeField] float speed = 5f;
    Camera currentCam;
    Animator animator;
    PlayerController controller;
    Rigidbody rb;
    Vector2 movementDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new Controls();
        controls.Game.Enable();
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        
    }

    void onMovement(InputValue value)
    {
        movementDirection = value.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get current camera
        currentCam = Camera.main;
        //makes variables for camera's forward and right positiions, setting y to 0 for both
        Vector3 camF = currentCam.transform.forward;
        Vector3 camR = currentCam.transform.right;
        camF.y = 0;
        camR.y = 0;


        Vector2 movementDirection = controls.Game.Movement.ReadValue<Vector2>();
        Vector3 movement = (camR * movementDirection.x + camF * movementDirection.y);
        /*Debug.Log(movement);
        movement.Normalize();
        debugText.text = movement.ToString();*/
        if (movementDirection != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            rb.velocity = new Vector3(movement.x * speed, 0, movement.z * speed);
            transform.forward = movement;
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);
        }
    }
}
