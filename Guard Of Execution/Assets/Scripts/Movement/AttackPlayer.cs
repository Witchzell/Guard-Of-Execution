using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator animator;

    [Header("Attack")]
    public Transform attackLocation;
    public float attackRange;
    public LayerMask Enemy;
    public int Combo = 0;

    // Update is called once per frame
    void Update()
    {
        // Attack Settings
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());

            //Damage
            Collider2D[] attack = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, Enemy);
            for (int i = 0; i < attack.Length; i++) 
            {
                if(attack[i].gameObject != gameObject)
                {
                    Destroy(attack[i].gameObject);
                }
            }
        }
    }

    private IEnumerator Attack()
    {
        animator.SetBool("Finish_Attack", false);
        Combo += 1;
        animator.SetInteger("Attacking", Combo);
        animator.SetBool("Finish_Attack", true);
        if(Combo == 3) 
        {
            Combo = 0;
        }

        yield return new WaitForSeconds(2);
    }
}
