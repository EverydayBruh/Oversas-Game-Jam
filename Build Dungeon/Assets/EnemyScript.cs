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

    /// <summary>
    /// ���������� ���������� ����� ������������ ��������� �������
    /// </summary>
    public Vector2 EnemySetPosition()
    {
        enemyPosition = new Vector2(enemyOffsetPosition.x, enemyOffsetPosition.y);
        return enemyPosition;
    }

    /// <summary>
    /// ���������� ���������� ����� ������������ ��������� �������
    /// </summary>
    public Vector3 GetKnightPosition()
    {
        knightPosition = new Vector2(enemyOffsetPosition.x, enemyOffsetPosition.y) * -1;
        return knightPosition;
    }

    public virtual void Attack()
    {
        // ���������� ����� ����� ��� ���� ������
    }

    public virtual void TakeDamage(float damage)
    {
        // ���������� ��������� ����� ����� ��� ���� ������
    }

}
