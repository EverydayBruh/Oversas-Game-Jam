using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemyOffsetPosition;
    public TileManager tileManager;

    // <summary>
    // Ало
    // </summary>
    public void EnemySetPosition(Room room)
    {
        Vector3 pos = room.transform.position +  new Vector3(enemyOffsetPosition * tileManager.distance_multiplier, room.transform.position.y, -1);
    }
}
