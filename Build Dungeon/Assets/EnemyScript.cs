using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector2 enemyOffsetPosition;
    public float health;
    public float strenght;
    public Vector2 enemyPosition;
    public Vector2 knightPosition;
    public bool isAttacking;

    public float Speed = 10f;
    private Vector3 velocity;


    private void Update()
    {
        if (isAttacking)
        {
            Attack();
        }
    }
    /// <summary>
    /// ќпредел€ет координаты врага относительно координат комнаты
    /// </summary>
    public Vector2 EnemySetPosition()
    {
        enemyPosition = new Vector2(enemyOffsetPosition.x, enemyOffsetPosition.y);
        return enemyPosition;
    }

    /// <summary>
    /// ќпредел€ет координаты врага относительно координат комнаты
    /// </summary>
    public Vector3 GetKnightPosition()
    {
        knightPosition = new Vector2(enemyOffsetPosition.x, enemyOffsetPosition.y) * -1;
        return knightPosition;
    }

    public virtual void Attack()
    {

        transform.position = Vector3.SmoothDamp(transform.position, knightPosition + Vector2.right, ref velocity, Speed);

    }

    public virtual void TakeDamage(float damage)
    {
        // –еализаци€ получени€ урона обща€ дл€ всех врагов
    }

}
