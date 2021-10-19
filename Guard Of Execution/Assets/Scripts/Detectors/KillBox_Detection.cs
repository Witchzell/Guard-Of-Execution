using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox_Detection : MonoBehaviour
{
    public Transform respawnPos; //This is the respawn position

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillBox") //Checking if the object has the tag "Killbox"
        {
            FadeSender = GameObject.FindGameObjectWithTag("").GetComponent<Fade>();

            while(fadeDeath == true)
            {
                Debug.Log("Science");
                return;
            }
            
            transform.position = respawnPos.position; //Bring the object to the respawn position
        }
    }
}
