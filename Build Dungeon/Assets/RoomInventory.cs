using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class RoomInventory : MonoBehaviour
{
    public TileManager tileManager;
    private List<Room> RoomsInventory;
    public EnemeisSpawner enemeisSpawner;
    public Room room;
    public int RoomInventoryCapacity = 7;
    public uint AmountForNewRoom = 2;
    public int currentRoomAmount = 0;
    public float distance_multiplier = 3f;
    public float y_inventoryOffset = 3;

    void Start()
    {
        CreateRoomInventory();
        CenterRoomInventory();
    }
    public void CreateRoomInventory()
    {
        RoomsInventory = new List<Room>(RoomInventoryCapacity);

        for (int x = 0; x < RoomInventoryCapacity; x++)
        {
            CreateRoom();
        }
    }

    /// <summary>
    /// Создает новую комнату в инвенторе.
    /// </summary>
    public void CreateRoom()
    {
        Room temp = Instantiate(room, this.transform);
        temp.GetComponent<Room>().Randomise();
        if (Random.value > 0.5f)
        {
            temp.enemy = enemeisSpawner.SpawnRandomEnemy(temp);
        }
        RoomsInventory.Add(temp);
        currentRoomAmount += 1;
    }
    /// <summary>
    /// Уменьшает счётчик комнат, находящихся в инвенторе, и создает новые, если комнат недостаточно.
    /// </summary>
    public void InventoryRemoveRoom(Room room)
    {
        RoomsInventory.Remove(room);
        currentRoomAmount -= 1;
        if (currentRoomAmount <= AmountForNewRoom)
        {
            CreateRoom();
        }
    }
    /// <summary>
    /// Обновляет инвентарь после добавления или удаления из него комнат.
    /// </summary>
    private void UpdateRoomInventory()
    {
        
    }

    public void CenterRoomInventory()
    {
        transform.position = new Vector3((tileManager.width * tileManager.distance_multiplier)/2, -3 - (y_inventoryOffset/2),0);
    }
}
