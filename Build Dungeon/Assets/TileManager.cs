using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tile;
    private GameObject[,] roomSlots; // Матрица RoomSlot

    public uint width; // Ширина матрицы
    public uint height; // Высота матрицы
    public float distance_multiplier = 3f;
    private GameObject tilemap;



    // Инициализация матрицы с пустыми RoomSlot
    public void UpdateSlots()
    {
        ClearRoomSlots();
        tilemap = new GameObject();//Instantiate(new GameObject(), new Vector3(0,0), new Quaternion());
        roomSlots = new GameObject[width, height];
        GameObject temp_tile;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x,y) * distance_multiplier;
                temp_tile = Instantiate(tile, pos, new Quaternion(), tilemap.transform);
                temp_tile.GetComponent<RoomSlot>().SetCoordinates(new Vector2(x, y));
                //temp_tile.transform.parent = tilemap.transform;
            }
        }
    }

    public GameObject ObjSlotByCoord(int x, int y)
    {
        if (x >= width || y >= height) return null;
        return roomSlots[x, y];

    }
    public RoomSlot SlotByCoord(int x, int y)
    {
        return ObjSlotByCoord(x,y).GetComponent<RoomSlot>();
    }

    public Room RoomByCoord(int x, int y)
    {
        return SlotByCoord(x, y).GetRoom();
    }

    // Метод для получения RoomSlot по координатам
    public GameObject GetRoomSlot(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return roomSlots[x, y];
        }

        return null;
    }

    public int ClearRoomSlots()
    {
        // Обнуляем каждый элемент матрицы RoomSlots
        Debug.Log("Clear Started");
        if (tilemap == null) { return 1; }
        foreach (Transform child in tilemap.transform)
        {
            Debug.Log(child.name);
            GameObject.DestroyImmediate(child.gameObject);
        }
        DestroyImmediate(tilemap);
        //if (roomSlots == null) return 1;

        //for (int x = 0; x < last_width; x++)
        //{
        //    for (int y = 0; y < last_heaight; y++)
        //    { 
        //        if(roomSlots[x, y]) roomSlots[x, y].RoomClear();
        //    }
        //}
        return 0;
        //roomSlots = null;
    }
}
