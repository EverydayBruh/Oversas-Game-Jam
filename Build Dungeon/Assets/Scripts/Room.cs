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
    public GameObject enemy;
    public EnemyScript enemyScript;
    private RoomInventory roomInventory;


    private void OnValidate()
    {
        UpdateDoors();
    }

    private void Awake()
    {
        TileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
        roomInventory = GameObject.FindGameObjectWithTag("RoomInventory").GetComponent<RoomInventory>();
    }
    /// <summary>
    /// Получем координаты, в которые может передвигаться рыцарь
    /// </summary>
    public Vector3 KnightPos()
    {
        if (enemy != null)
        {
            enemyScript = enemy.GetComponent<MonoBehaviour>() as EnemyScript;
            return gameObject.transform.position + enemyScript.GetKnightPosition() * TileManager.distance_multiplier + Vector3.back * 5;
        }
        else
        {
            return gameObject.transform.position + Vector3.back * 5;
        }
    }

    /// <summary>
    /// Получем направления, в которых может двигаться рыцарь
    /// </summary>
    public Vector2[] GetDirectons()
    {
        int k = 0;
        for (int i = 0; i<4;i++)
        {
            if (doors[i] && (neighbors[i] == null))
            {
                k++;
            }
        }
        Vector2[] array = new Vector2[k];
        k = 0;
        for (int i = 0; i < 4; i++)
        {
            if (doors[i] && (neighbors[i] == null))
            {
                array[k] = IndexToDirection(i);
                k++;
            }
        }
        return array;
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
        if (this.name.StartsWith("Room")){
            this.name = coordinates.x.ToString() + " " + coordinates.y.ToString()+ "Room";
        }
        roomInventory.InventoryRemoveRoom(this);
    }

    /// <summary>
    /// Обновляяем двери и соседей
    /// </summary>
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
        if (!TileManager.CheckCoordinates((int)coord.x, (int)coord.y))
        {
            doors[DirectionToIndex(direction)] = false;
            return -1;
        }
        Room room = TileManager.RoomByCoord((int)coord.x, (int)coord.y);
        //Debug.Log(room);
        if(room== null) return-1;
        //Debug.Log(room.name);
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

    
    public Room GetRoomInDirection(Vector2 direction)
    {
        return neighbors[DirectionToIndex(direction)];
    }

    public RoomSlot GetSlotInDirection(Vector2 direction)
    {
        Vector2 slotpos= this.coordinates + direction;
        return TileManager.GetRoomSlot((int)slotpos.x, (int)slotpos.y).GetComponent<RoomSlot>();
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


// Перечисление для представления направлений
public enum Direction
{
    Top = 0,
    Right = 1,
    Bottom = 2,
    Left = 3
}