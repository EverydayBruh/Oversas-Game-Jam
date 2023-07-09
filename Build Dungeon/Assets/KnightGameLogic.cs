using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightGameLogic : MonoBehaviour
{
    public Room spawnRoom;
    public Room curRoom;
    private KnightScript knight;
    public GameObject rooms;
    private TileManager tileManager;

    private void Awake()
    {
        knight = GetComponent<KnightScript>();
        tileManager = FindAnyObjectByType<TileManager>();
    }
    void Start()
    {
        ChangeRoom(spawnRoom);
    }

    /// <summary>
    /// Обрабатываеми поведение рыцаря в текущей комнате
    /// </summary>
    public void EnterRoom() 
    {
        Debug.Log("EnterRoom");
        StartCoroutine(StartWalkinInDirection(chooseDirection()));
        

    }

    private IEnumerator StartWalkinInDirection(Vector3 direction)
    {
        Debug.Log("StartWalkinInDirection" + direction.ToString());
        Vector3 pos = gameObject.transform.position + direction * tileManager.distance_multiplier * 0.4f;
        knight.MoveToPoint(pos);
        while (curRoom.GetRoomInDirection(direction) == null)
        {
            yield return null;
        }
        ChangeRoom(curRoom.GetRoomInDirection(direction));
    }

    public void ChangeRoom(Room room)
    {
        Debug.Log("ChangeRoom");
        StartCoroutine(ChangeRoomCoroutine(room));
    }

    private IEnumerator ChangeRoomCoroutine(Room room)
    {
        Debug.Log("ChangeRoom Timer");
        knight.MoveToRoom(room);
        while (knight.isWalking)
        {
            yield return null;
        }
        curRoom = room;
        yield return new WaitForSeconds(0.6f);
        EnterRoom();
    }
    private Vector2 chooseDirection()
    {
        Vector2[] directions = curRoom.GetDirectons();
        if (directions.Length == 0) return Vector2.zero;

        int randomIndex = UnityEngine.Random.Range(0, directions.Length);
        Vector2 randomDir = directions[randomIndex];
        foreach (Vector2 direction in directions) { Debug.Log("\n Direction: " + direction.ToString()); }
        
        return randomDir;
    }
}
