using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death : MonoBehaviour
{
    
    Fade DeathStarter;
    public bool fadeDeath = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            fadeDeath = true;
            DeathStarter = GameObject.FindGameObjectWithTag("Fade").GetComponent<Fade>();
            DeathStarter.DeathStarter();
        }
    }
}
