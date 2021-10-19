using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    // Public for ease of change in the inspector (unity)
    public float runSpeed = 5f;
    private float horizontalSpeed = 0f;
    public int Combo = 0;

    bool jump = false;

    public Animator animator;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement Settings
        horizontalSpeed = Input.GetAxisRaw("Horizontal") * runSpeed; // Input from player

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true); // Jumping animation
        }
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed)); // Animation for running
        animator.SetFloat("Falling", rb.velocity.y);

        // Attack Settings
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Finish_Attack", false);
            Combo += 1;
            animator.SetInteger("Attacking", Combo);
            animator.SetBool("Finish_Attack", true);
            if(Combo == 3) 
            {
                Combo = 0;
            }
        }
    }

    void FixedUpdate() //character movement
    {
        controller.Move(horizontalSpeed * Time.fixedDeltaTime, false, jump);
        animator.SetBool("Jumping", false);
        jump = false;
        animator.SetInteger("Attacking", 0);
    }
}
