using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject[,] roomSlots; // Матрица RoomSlot

    public uint width; // Ширина матрицы
    public uint height; // Высота матрицы
    public float distance_multiplier = 3f;
    private GameObject tilemap;



    // Инициализация матрицы с пустыми RoomSlot
    private void Start()
    {
        FindSlots();
    }
    [ContextMenu("Update Slots")]
    public void UpdateSlots()
    {
        ClearRoomSlots();
        tilemap = new GameObject();//Instantiate(new GameObject(), new Vector3(0,0), new Quaternion());
        tilemap.name = "TileMap";
        tilemap.transform.position= new Vector3(distance_multiplier/ 2, distance_multiplier / 2);
       
        roomSlots = new GameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = tilemap.transform.position + new Vector3(x,y) * distance_multiplier;
                roomSlots[x, y] = Instantiate(tile, pos, new Quaternion(), tilemap.transform);
                roomSlots[x, y].GetComponent<RoomSlot>().SetCoordinates(new Vector2(x, y));
                roomSlots[x,y].name = x.ToString()+" "+ y.ToString();
                //temp_tile.transform.parent = tilemap.transform;
            }
        }
    }

    public void FindSlots()
    {
        tilemap = GameObject.Find("TileMap");
        roomSlots = new GameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                roomSlots[x, y] = GameObject.Find(x.ToString() + " " + y.ToString());
                roomSlots[x, y].GetComponent<RoomSlot>().SetCoordinates(new Vector2(x, y));
                //Debug.Log(roomSlots[x, y].name);
            }
        }
    }

    public GameObject GetRoomSlot(Vector2 position)
    {
        if(position.x < 0 || position.y < 0) return null;
        position = position / distance_multiplier;
        return ObjSlotByCoord((int)position.x / 1,(int)position.y / 1);
    }
    public GameObject ObjSlotByCoord(int x, int y)
    {
        //.Debug.Log(x);
        //Debug.Log(y);
        if (!CheckCoordinates(x,y)) return null;
        //Debug.Log("Coord OK");
        return roomSlots[x, y];

    }
    public RoomSlot SlotByCoord(int x, int y)
    {
        if (!CheckCoordinates(x, y)) return null;
        return ObjSlotByCoord(x,y).GetComponent<RoomSlot>();
    }

    public Room RoomByCoord(int x, int y)
    {
        if (!CheckCoordinates(x, y)) return null;
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
        return 0;
    }
    public bool CheckCoordinates(int x, int y) //false если неправильные координаты
    {
        if (x >= width || y >= height || x < 0 || y < 0) return false;
        return true;
    }
}
