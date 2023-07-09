using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Room : MonoBehaviour
{
    public bool IsPlaced = false;
    public bool[] doors = new bool[4];
    public GameObject[] walls;
    public Room[] neighbors = new Room[4];
    private Vector2 coordinates = Vector2.zero;
    private TileManager TileManager;


    private void OnValidate()
    {
        UpdateDoors();
    }

    private void Awake()
    {
        TileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }

    public void UpdateDoors()
    {
        for(int i = 0; i<4; i++)
        {
            walls[i].GetComponent<Wall>().haveDoor = doors[i];
            walls[i].GetComponent<Wall>().UpdateSprite();
        }
    }

    public void Place(Vector2 coordinate, Vector3 position)
    {
        this.coordinates = coordinate;
        IsPlaced = true;
        this.transform.position = position;
        UpdateConnections();
       //this.GetComponent<DragScript>().enabled= false;
        this.name = coordinates.x.ToString() + "; " + coordinates.y.ToString();
    }

    public void UpdateConnections() 
    {
        for(int i = 0; i<4; i++)
        {
            UpdateConnection(IndexToDirection(i));
        }
        UpdateDoors();
    }

    public int UpdateConnection(Vector2 direction)
    {
        Vector2 coord = this.coordinates + direction;
        Room room = TileManager.RoomByCoord((int)coord.x, (int)coord.y);
        //Debug.Log(room);
        if(room== null) return-1;
        Debug.Log(room.name);
        if (doors[DirectionToIndex(direction)] || room.doors[DirectionToIndex(-direction)])
        {
            doors[DirectionToIndex(direction)] = true;
            room.doors[DirectionToIndex(-direction)] = true;
            neighbors[DirectionToIndex(direction)] = room;
            room.neighbors[DirectionToIndex(-direction)] = this;
            room.UpdateDoors();
        }

        return 0;
    }
    public void Randomise()
    {
        for (int i = 0; i < 4; i++)
        {
            doors[i] = (Random.value > 0.5f);
        }
        UpdateDoors();
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
        if (direction == Vector2.right) return 1;
        if (direction == Vector2.down) return 2;
        if (direction == Vector2.left) return 3;
        return -1;
    }

    public Vector2 IndexToDirection(int i)
    {
        if (i == 0) return Vector2.up;
        if (i == 1) return Vector2.right;
        if (i == 2) return Vector2.down;
        if (i == 3) return Vector2.left;
        return Vector2.zero;
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