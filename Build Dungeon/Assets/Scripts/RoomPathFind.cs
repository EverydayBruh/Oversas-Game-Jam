using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPathFind 
{
    public static Room[] FindWay(Room startRoom, Room targetRoom)
    {
        // ������� ������� ��� ������������ ������� ������ �� ����� ������
        Dictionary<Room, Room> parentMap = new Dictionary<Room, Room>();

        // ������� ������� ��� ������ � ������
        Queue<Room> queue = new Queue<Room>();
        queue.Enqueue(startRoom);

        // �������� ��������� ������� ��� ����������
        HashSet<Room> visited = new HashSet<Room>();
        visited.Add(startRoom);

        // ���� ������� �� �����, ���������� �����
        while (queue.Count > 0)
        {
            Room currentRoom = queue.Dequeue();

            // ���� ���������� ������� �������, ������ ������� � ���������� ���
            if (currentRoom == targetRoom)
                return BuildPath(parentMap, startRoom, targetRoom);

            // ���������� �������� �������
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

        // ���� �� ������
        return null;
    }

    // ��������������� ������� ��� ���������� �������� �� ������ ������� �������
    private static Room[] BuildPath(Dictionary<Room, Room> parentMap, Room startRoom, Room targetRoom)
    {
        List<Room> path = new List<Room>();
        Room currentRoom = targetRoom;

        // �������� ������ �� ������� ������� � ���������
        while (currentRoom != startRoom)
        {
            path.Add(currentRoom);
            currentRoom = parentMap[currentRoom];
        }

        // ��������� ��������� �������
        path.Add(startRoom);

        // ����������� �������, ����� �������� ���������� ����
        path.Reverse();

        return path.ToArray();
    }

    public static void PrintPath(Room[] path)
    {
        if (path != null)
        {
            Debug.Log("���� ������:");
            foreach (Room room in path)
            {
                Debug.Log(room.name);
            }
        }
        else
        {
            Debug.Log("���� �� ������.");
        }
    }

    public static void PrintPath(List<Room> path)
    {
        if (path != null)
        {
            Debug.Log("���� ������:");
            foreach (Room room in path)
            {
                Debug.Log(room.name);
            }
        }
        else
        {
            Debug.Log("���� �� ������.");
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

            // ���������� ��� �������� �������
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
