using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tile;
    private RoomSlot[,] roomSlots; // ������� RoomSlot

    public int width; // ������ �������
    public int height; // ������ �������
    private int last_width;
    private int last_heaight;
    private GameObject tilemap;



    // ������������� ������� � ������� RoomSlot
    void OnValidate()
    {
        ClearRoomSlots();
        tilemap = Instantiate(new GameObject());
        roomSlots = new RoomSlot[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                roomSlots[x, y] = new RoomSlot(new Vector2(x, y), tile, tilemap);
            }
        }
        last_width= width;
        last_heaight= height;
    }
    
    

    // ����� ��� ��������� RoomSlot �� �����������
    public RoomSlot GetRoomSlot(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return roomSlots[x, y];
        }

        return null;
    }

    public int ClearRoomSlots()
    {
        // �������� ������ ������� ������� RoomSlots
        if(tilemap == null) { return 1; }
        foreach (Transform child in tilemap.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Destroy(tilemap);
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
