using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPathFind 
{
    public static Room[] FindWay(Room startRoom, Room targetRoom)
    {
        // Создаем словарь для отслеживания предков комнат во время обхода
        Dictionary<Room, Room> parentMap = new Dictionary<Room, Room>();

        // Создаем очередь для обхода в ширину
        Queue<Room> queue = new Queue<Room>();
        queue.Enqueue(startRoom);

        // Помечаем начальную комнату как посещенную
        HashSet<Room> visited = new HashSet<Room>();
        visited.Add(startRoom);

        // Пока очередь не пуста, продолжаем обход
        while (queue.Count > 0)
        {
            Room currentRoom = queue.Dequeue();

            // Если достигнута целевая комната, строим маршрут и возвращаем его
            if (currentRoom == targetRoom)
                return BuildPath(parentMap, startRoom, targetRoom);

            // Перебираем соседние комнаты
            foreach (Room neighbor in currentRoom.neighbors)
            {
                if (neighbor != null && !visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                    parentMap[neighbor] = currentRoom;
                }
            }
        }

        // Путь не найден
        return null;
    }

    // Вспомогательная функция для построения маршрута на основе словаря предков
    private static Room[] BuildPath(Dictionary<Room, Room> parentMap, Room startRoom, Room targetRoom)
    {
        List<Room> path = new List<Room>();
        Room currentRoom = targetRoom;

        // Обратный проход от целевой комнаты к начальной
        while (currentRoom != startRoom)
        {
            path.Add(currentRoom);
            currentRoom = parentMap[currentRoom];
        }

        // Добавляем начальную комнату
        path.Add(startRoom);

        // Инвертируем порядок, чтобы получить правильный путь
        path.Reverse();

        return path.ToArray();
    }

    public static void PrintPath(Room[] path)
    {
        if (path != null)
        {
            Debug.Log("Путь найден:");
            foreach (Room room in path)
            {
                Debug.Log(room.name);
            }
        }
        else
        {
            Debug.Log("Путь не найден.");
        }
    }

    public static void PrintPath(List<Room> path)
    {
        if (path != null)
        {
            Debug.Log("Путь найден:");
            foreach (Room room in path)
            {
                Debug.Log(room.name);
            }
        }
        else
        {
            Debug.Log("Путь не найден.");
        }
    }

    public static  List<Room> HasWay(Room room)
    {
        List<Room> reachableRooms = new List<Room>();
        Queue<Room> queue = new Queue<Room>();
        HashSet<Room> visited = new HashSet<Room>();

        queue.Enqueue(room);
        visited.Add(room);

        while (queue.Count > 0)
        {
            Room currentRoom = queue.Dequeue();
            reachableRooms.Add(currentRoom);

            // Перебираем все соседние комнаты
            foreach (Room neighbor in currentRoom.neighbors)
            {
                if (neighbor!=null && !visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }

        return reachableRooms;
    }

    public static bool Freedors(Room room) 
    {
        bool answ = false;
        for(int i = 0; i<4; i++)
        {
            if (room.doors[i] && room.neighbors[i] == null)
            {
                answ = true;
            }
        }
        return answ;
    }

}
