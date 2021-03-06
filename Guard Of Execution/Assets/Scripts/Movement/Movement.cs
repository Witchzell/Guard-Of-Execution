using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    // Public for ease of change in the inspector (unity)
    [Header("Movement")]
    public float runSpeed = 5f;
    private float horizontalSpeed = 0f;
    bool jump = false;

    [Header("Dependencies")]
    public Animator animator;
    private Rigidbody2D rb;
    public PlayerDeath PlayerDeath;

    [Header("Knockback")]
    public int knock = 10;
    public int knockUp = 10;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
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

        //Knockback
        if(PlayerDeath.hp != PlayerDeath.newHp)
        {
            //Direction of knockback
            // Vector3 direction = (playerPos - enemyPos).normalized; For the future
            rb.AddForce(new Vector2(-knock, knockUp));
            PlayerDeath.newHp = PlayerDeath.hp;
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
