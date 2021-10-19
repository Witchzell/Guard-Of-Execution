using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox_Detection : MonoBehaviour
{
    public Transform respawnPos; //This is the respawn position
    public bool fadeDeath = false;

    Fade Fade;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillBox") //Checking if the object has the tag "Killbox"
        {
            StartCoroutine(Until());
        }
    }

    public IEnumerator Until()
    {
        fadeDeath = true;

        Fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>(); //Unoptimised, but it works
        Fade.DeathStarter();

        yield return new WaitWhile(() => fadeDeath == false);

        Fade.DeathLeaver();
        transform.position = respawnPos.position; //Bring the object to the respawn position
        
    }

}
