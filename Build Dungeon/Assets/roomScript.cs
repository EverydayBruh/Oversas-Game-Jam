using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public Room[] neighbors = new Room[4];
    
    public void SetNeighbors(Room top, Room right, Room bottom, Room left)
    {
        neighbors[0] = top;
        neighbors[1] = right;
        neighbors[2] = bottom;
        neighbors[3] = left;
    }

    public void AddRoom(Direction direction, Room newRoom)
    {
        int index = (int)direction;

        if (index >= 0 && index < neighbors.Length)
        {
            neighbors[index] = newRoom;
            newRoom.neighbors[(index + 2) % 4] = this;
        }
    }
}

// Перечисление для представления направлений
public enum Direction
{
    Top = 0,
    Right = 1,
    Bottom = 2,
    Left = 3
}