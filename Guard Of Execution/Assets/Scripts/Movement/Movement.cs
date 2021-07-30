using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    // Public for ease of change in the inspector (unity)
    public float runSpeed = 5f;
    private float horizontalSpeed = 0f;

    bool jump = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal") * runSpeed; // Input from player

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Debug.Log (jump);
        }
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed)); // Animation for running

    }

    void FixedUpdate() //character movement
    {
        controller.Move(horizontalSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
