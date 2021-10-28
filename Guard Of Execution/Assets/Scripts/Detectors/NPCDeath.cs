using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeath : MonoBehaviour
{
    [Header("Respawn Area")]
    public Transform respawnPos; //This is the respawn position
    PlayerDeath pD;

    [Header("Enemy")]
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillBox") //Checking if the object has the tag "Killbox"
        {
            Enemy.SetActive(false);
        }
    }
}
