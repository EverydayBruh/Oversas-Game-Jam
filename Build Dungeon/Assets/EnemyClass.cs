using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector2 enemyOffsetPosition;
    public float health;
    public float strenght;
    public TileManager tileManager;
    private Vector3 enemyPosition;

    /// <summary>
    /// Определяет координаты врага относительно координат комнаты
    /// </summary>
    public Vector3 EnemySetPosition(Room room)
    {
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
        return enemyPosition = room.transform.position + new Vector3(enemyOffsetPosition.x, enemyOffsetPosition.y,0) * tileManager.distance_multiplier + Vector3.back;
    }

    public virtual void Attack()
    {
        // Реализация атаки общая для всех врагов
    }

    public virtual void TakeDamage(float damage)
    {
        // Реализация получения урона общая для всех врагов
    }

}
