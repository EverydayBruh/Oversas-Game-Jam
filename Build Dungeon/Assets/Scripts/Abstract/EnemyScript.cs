using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : Entity
{
    public Vector2 enemyOffsetPosition;
    public Vector2 enemyPosition;
    public Vector2 knightPosition;
    private int damage = 0;


    /// <summary>
    /// Определяет координаты врага относительно координат комнаты
    /// </summary>
    public Vector2 EnemySetPosition()
    {
        enemyPosition = new Vector2(enemyOffsetPosition.x, enemyOffsetPosition.y);
        return enemyPosition;
    }

    /// <summary>
    /// Определяет координаты врага относительно координат комнаты
    /// </summary>
    public Vector3 GetKnightPosition()
    {
        knightPosition = new Vector2(enemyOffsetPosition.x, enemyOffsetPosition.y) * -1;
        return knightPosition;
    }

    

}
