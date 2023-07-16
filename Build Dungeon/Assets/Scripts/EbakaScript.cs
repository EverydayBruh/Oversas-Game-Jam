using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbakaScript : EnemyScript
{
    [Header("Ebaka Animation Settings")]
    public Animator animator;

    public override void Attack(Entity victim)
    {
        base.Attack(victim);
        animator.SetTrigger("Attack");
        animator.SetTrigger("Stay");
    }
    public override void TakeDamage(int damage, Entity source)
    {
        base.TakeDamage(damage, source);
        animator.SetTrigger("TakeDmg");
        animator.SetTrigger("Stay");
    }

    public override void Die()
    {
        base.Die();
        animator.SetTrigger("Death");

    }
}
