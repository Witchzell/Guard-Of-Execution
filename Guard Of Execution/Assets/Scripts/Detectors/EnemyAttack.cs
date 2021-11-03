using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://weeklyhow.com/unity-2d-melee-combat-tutorial/

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack")]
    public Transform attackLocation;
    public float attackRange;
    public PlayerDeath PlayerDeath;
    public LayerMask Player;

    //For animation reference
    [Header("Animation")]
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other) //Animation
    {
        if(other.gameObject.tag == "Player") //Checking if the object has the tag "Player"
        {
            animator.SetBool("Attacking", true);

            //Damage
            Collider2D[] hit = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, Player);
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].gameObject != gameObject)
                {
                    PlayerDeath.hp -= 1;
                    Debug.Log(PlayerDeath.hp);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Animation
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetBool("Attacking", false);
        }
    }
}
