using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Public for ease of change in the inspector (unity)
    public float moveSpeed = 5f; // Horizontal mov
    public float jUp = 5f; // Vertical mov
    public bool Grounded = false; // Is player on the floor

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed; //Change players speed taking in consideration of variables
    }

    void Jump() //Jumping code
    {
        if (Input.GetButtonDown("Jump") && Grounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jUp), ForceMode2D.Impulse);
        }
    }
}
