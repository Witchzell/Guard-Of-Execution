using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Pathfinding;

//https://www.youtube.com/watch?v=sWqRfygpl4I } Gigachad
public class EnemyBrain : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target; //Target to attack
    public float detectionDistance = 10f; //Distance of detection
    public float pathRefresh = 0.8f; //Refresh rate of A* path

    [Header("Physics")]
    public float speed = 200f;
    public float distaceToFollow = 2f; //Distance for the enemy to start following player again
    public float jumpNodeRequirement = 0.8f; //Distance required between nodes for it to jump
    public float jumpForce = 200f; //How powerfull the jump is

    [Header("Custom Behaviour")]
    public bool followOrNot = true; //Does the enemy want to follow?
    public bool jumpOrNot = true; //Allow to jump?
    public bool lookingRight = true; //Sprite changing direction to follow player?
    [SerializeField] private LayerMask WhatIsGround;

    //Path features
    private Path path;
    private int currentPath = 0;
    
    //Movement
    [Header("Movement")]
    [SerializeField] private Transform GroundCheck; //Jump
    private bool Grounded;
    const float GroundedRadius = .2f;

    public UnityEvent OnLandEvent;
    Seeker hunt; //Referencing other script
    Rigidbody2D rb; //Referencing rigidbody

    private void Awake()
    {
        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }

    public void Start()
    {
        hunt = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathRefresh); //Refreshing path by the pathRefresh rate 
                                                        //Done to increase performance
    }

    private void FixedUpdate()
    {
        if(TargetDetected() && followOrNot)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if(followOrNot && TargetDetected() && hunt.IsDone())
        {
            hunt.StartPath(rb.position, target.position, pathCompletion);
        }
    }

    private void PathFollow()
    {
        if(path == null)
        {
            return;
        }

        //End of path
        if(currentPath >= path.vectorPath.Count)
        {
            return;
        }

        //Checking for collisions
        bool wasGrounded = Grounded;
        Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);

        for (int i = 0; i < colliders.Length; i++)
		{
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
		}
    
        //Direction calc
        Vector2 direction = ((Vector2)path.vectorPath[currentPath] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime; //Force created for direction

        if(jumpOrNot && Grounded == true) //Jumping requirements
        {
            if(direction.y > jumpNodeRequirement)
            {
                Grounded = false;
			    rb.AddForce(new Vector2(0f, jumpForce));
            }
        }

        //Movement
        rb.AddForce(force);

        //Next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentPath]);
        if(distance < distaceToFollow)
        {
            currentPath++; //Incremeting path if path is ideal
        }

        //Flipping sprite from direction
        if(lookingRight)
        {
            if(rb.velocity.x < 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if(rb.velocity.x > -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private bool TargetDetected()
    {
        return Vector2.Distance(transform.position, target.transform.position) < detectionDistance; //Checking if inside activate distance
    }

    private void pathCompletion(Path p)
    {
        if(!p.error) //if no error setting to 0
        {
            path = p;
            currentPath = 0;
        }
    }
}
