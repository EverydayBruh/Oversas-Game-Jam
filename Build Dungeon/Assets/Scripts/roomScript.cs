using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool IsPlaced = false;
    public bool[] doors = new bool[4];
    private Room[] neighbors = new Room[4];
    

    public void Place(Vector2 coordinate)
    {

    }
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

// ѕеречисление дл€ представлени€ направлений
public enum Direction
{
    Top = 0,
    Right = 1,
    Bottom = 2,
    Left = 3
}