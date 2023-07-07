using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tile;
    private RoomSlot[,] roomSlots; // Матрица RoomSlot

    public int width; // Ширина матрицы
    public int height; // Высота матрицы


    

    // Инициализация матрицы с пустыми RoomSlot
    void OnValidate()
    {
        ClearRoomSlots();

        roomSlots = new RoomSlot[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                roomSlots[x, y] = new RoomSlot(new Vector2(x, y), tile);
            }
        }
    }
    
    

    // Метод для получения RoomSlot по координатам
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
        // Обнуляем каждый элемент матрицы RoomSlots
        if (roomSlots == null) return 1;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            { 
                if(roomSlots[x, y]) roomSlots[x, y].RoomClear();
            }
        }
        return 0;
        //roomSlots = null;
    }
}
