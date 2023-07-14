

using System.Collections.Generic;
using UnityEngine;

public class Entity: MonoBehaviour
{
    public bool IsAlive = true;
    public float attackDelay = 1f; // Задержка между атаками (в секундах)
    private int damage = 1;
    private int health = 3;
    public virtual void Attack(List<Entity> victims)
    {
        Entity randomVictim = victims[Random.Range(0, victims.Count)];
        Attack(randomVictim);
    }

    public virtual void Attack(Entity victim)
    {
        Debug.Log(this.name + " attacked " + victim.name);
        victim.TakeDamage(damage, this);
    }

    public virtual void TakeDamage(int damage, Entity source)
    {
        Debug.Log(this.name + $" tooked {damage}damage from"+ source.name);
        health -= damage;
        if(health< 0) { Die(); }
    }

    public virtual void Die()
    {
        Debug.Log(this.name + " is dead!");

        IsAlive = false;
    }

}
