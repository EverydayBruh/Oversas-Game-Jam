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
    public Camera mainCamera;
    public int RoomInventoryCapacity = 7;
    public uint AmountForNewRoom = 2;
    private int currentRoomAmount = 0;
    private float y_inventoryOffset;
    private float firstScale = 4.3f;

    void Start()
    {
        CreateRoomInventory();
        //CenterRoomInventory();
        y_inventoryOffset = tileManager.distance_multiplier;
}
    private void Update()
    {
        UpdateRoomInventory();
        CenterRoomInventory();
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
            CreateRoom(currentRoomAmount * y_inventoryOffset);
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
            float new_scale = firstScale / mainCamera.GetComponent<CameraPositionScript>().ratio;
            RoomsInventory[x].transform.localScale = new Vector3(new_scale, new_scale, new_scale);
            Vector3 new_pos = transform.position + new Vector3((x - currentRoomAmount / 2) * y_inventoryOffset - y_inventoryOffset / 2 * (currentRoomAmount % 2 - 1), 0, 0) / mainCamera.GetComponent<CameraPositionScript>().ratio;
            RoomsInventory[x].transform.position = Vector3.Lerp(RoomsInventory[x].transform.position, new_pos, smoothTime * Time.deltaTime);
        }      
    }

    public void CenterRoomInventory()
    {
        //transform.position = new Vector3((tileManager.width * tileManager.distance_multiplier)/2, -3 - (y_inventoryOffset/2),-6);
        transform.position = mainCamera.transform.position + new Vector3(0,-6 / mainCamera.GetComponent<CameraPositionScript>().ratio, 5 / mainCamera.GetComponent<CameraPositionScript>().ratio);
    }

    public bool IsInInventory(Room room)
    {
        if (RoomsInventory == null) return false;
        return RoomsInventory.Contains(room);
    }
}
