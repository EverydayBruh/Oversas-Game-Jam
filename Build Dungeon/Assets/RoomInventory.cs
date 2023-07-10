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
    public EnemiesSpawner enemiesSpawner;
    public Room room;
    public int RoomInventoryCapacity = 7;
    public uint AmountForNewRoom = 2;
    private int currentRoomAmount = 0;
    public float y_inventoryOffset = 3;

    void Start()
    {
        CreateRoomInventory();
        CenterRoomInventory();
    }
    private void Update()
    {
        UpdateRoomInventory();
    }
    public void CreateRoomInventory()
    {
        RoomsInventory = new List<Room>(RoomInventoryCapacity);

        for (int x = 0; x < RoomInventoryCapacity; x++)
        {
            CreateRoom(0);
        }
    }

    /// <summary>
    /// Создает новую комнату в инвенторе.
    /// </summary>
    public void CreateRoom(float x)
    {
        Room temp = Instantiate(room, new Vector3(x,-10,0), new Quaternion(), this.transform);
        temp.GetComponent<Room>().Randomise();
        if (Random.value > 0.5f)
        {
            temp.enemy = enemiesSpawner.SpawnRandomEnemy(temp);
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
            CreateRoom(currentRoomAmount * tileManager.distance_multiplier);
        }
        RoomsInventory.TrimExcess();
    }

    public float smoothTime = 10F;

    /// <summary>
    /// Обновляет инвентарь после добавления или удаления из него комнат.
    /// </summary>
    private void UpdateRoomInventory()
    {
        for (int x = 0; x < currentRoomAmount; x++)
        {
            Vector3 new_pos = transform.position + new Vector3((x - currentRoomAmount / 2) * tileManager.distance_multiplier - tileManager.distance_multiplier / 2 * (currentRoomAmount % 2 - 1), 0, 0);
            RoomsInventory[x].transform.position = Vector3.Lerp(RoomsInventory[x].transform.position, new_pos, smoothTime * Time.deltaTime);
        }      
    }

    public void CenterRoomInventory()
    {
        transform.position = new Vector3((tileManager.width * tileManager.distance_multiplier)/2, -3 - (y_inventoryOffset/2),0);
    }
}
