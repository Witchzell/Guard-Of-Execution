using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeath : MonoBehaviour
{
    [Header("Respawn Area")]
    public Transform respawnPos; //This is the respawn position
    PlayerDeath pD;

    [Header("Hp")] //Health of the monster, for future implementations
    public int maxHp = 5;
    public int newHp;
    public int hp;

    [Header("Enemy")]
    public GameObject Enemy;

    private void Awake()
    {
        hp = maxHp; //For the future
        newHp = hp;
        transform.position = respawnPos.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "KillBox") //Checking if the object has the tag "Killbox"
        {
            hp = 0;
        }
    }

    private void Update()
    {
        if(hp == 0)
        {
            Enemy.SetActive(false);
        }
    }
}
