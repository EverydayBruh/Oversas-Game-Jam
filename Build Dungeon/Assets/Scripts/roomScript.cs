using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool IsPlaced = false;
    public bool[] doors = new bool[4];
    private Room[] neighbors = new Room[4];
    private Vector2 coordinates = Vector2.zero;


    public void Place(Vector2 coordinate)
    {
        this.coordinates = coordinate;
        IsPlaced = true;

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

    public Room GetNeighbor(Vector2 direction)
    {
        return neighbors[DirectionToIndex(direction)];
    }
    public bool IsConnected(Vector2 direction)
    {
        if (neighbors[DirectionToIndex(direction)] == null) return false;
        return true;
    }
    public int DirectionToIndex(Vector2 direction)
    {
        if (direction == Vector2.up) return 0;
        if (direction == Vector2.left) return 1;
        if (direction == Vector2.down) return 2;
        if (direction == Vector2.right) return 3;
        return -1;
    }

    public void SetCoordinates(Vector2 coordinate)
    {
        this.coordinates = coordinate;
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