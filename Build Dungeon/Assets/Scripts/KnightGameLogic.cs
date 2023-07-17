using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightGameLogic : MonoBehaviour
{
    public Room spawnRoom;
    public Room curRoom;
    private KnightScript knight;
    private List<Room> visitedRooms = new List<Room>();
    private TileManager tileManager;
    private RoomPathFind roomPathFind = new RoomPathFind();

    private void Awake()
    {
        knight = GetComponent<KnightScript>();
        tileManager = FindAnyObjectByType<TileManager>();
    }
    void Start()
    {
        ChangeRoom(spawnRoom);
    }

    private void EnterRoomVoid()
    {
        EnterRoom();
    }

    /// <summary>
    /// Обрабатываеми поведение рыцаря в текущей комнате
    /// </summary>
    private int EnterRoom() 
    {

        if(!visitedRooms.Contains(curRoom)) visitedRooms.Add(curRoom);
        Debug.Log("EnterRoom");

        if(curRoom.HasAliveEnemy())
        {
            StartCoroutine(FightRoutine());
            return 0;
        }

        if (curRoom.GetDirectons().Length > 0)
        {
            StartCoroutine(StartWalkinInDirection(chooseDirection()));
        } else
        {
            Room room = FindInterestingRoom();
            if (room == null) 
            {

                Debug.Log("DIE!!");
                Destroy(gameObject);
            }
            StartCoroutine(StartWalkinToRoom(room));
        }
        return 0;
    }

    private IEnumerator FightRoutine()
    {
        List<Entity> siteA = new List<Entity>();
        siteA.Add(gameObject.GetComponent<Entity>());
        List<Entity> siteB = new List<Entity>();
        siteB.AddRange(curRoom.EnemyList());

        Coroutine myCoroutine = StartCoroutine(FightLogic.FightCoroutine(siteA, siteB, () => EnterRoom()));
        //while (myCoroutine != null)
        //{
        //    //Debug.Log(myCoroutine.ToString());
        //    yield return null;
        //}
        //EnterRoom();
        yield return null;
    }

    private IEnumerator StartWalkinToRoom(Room room)
    {
        Debug.Log("StartWalkinToRoom");
        Room[] path = RoomPathFind.FindWay(curRoom, room);
        //RoomPathFind.PrintPath(path);
        int i = 0;
        while(curRoom != room)
        {
            knight.MoveToRoom(path[i]);
            while (knight.isWalking)
            {
                yield return null;
            }
            curRoom = path[i];
            i++;
        }
        EnterRoom();
    }



    public Room FindInterestingRoom()
    {
        Debug.Log("FindInterestingRoom");
        List<Room> reacheble = RoomPathFind.HasWay(curRoom);
        //RoomPathFind.PrintPath(reacheble);
        List<Room> interestingRooms = new List<Room>();

        foreach (Room room in reacheble)
        {
            if (IsInteresting(room))
            {
                interestingRooms.Add(room);
            }
        }
       //RoomPathFind.PrintPath(interestingRooms);
        if (interestingRooms.Count == 0) { return null; }
        return interestingRooms[Random.Range(0, interestingRooms.Count)];
    }

    /// <summary>
    /// Выбираем случайное напрвление и ждём пока не поставят комнату
    /// </summary>
    private IEnumerator StartWalkinInDirection(Vector3 direction)
    {
        Debug.Log("StartWalkinInDirection" + direction.ToString());
        Vector3 pos = gameObject.transform.position + direction * tileManager.distance_multiplier * 0.4f;
        knight.MoveToPoint(pos);
        curRoom.GetSlotInDirection(direction).Unlock();
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

        Room[] path = RoomPathFind.FindWay(curRoom, spawnRoom);
        //RoomPathFind.PrintPath(path);
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

    public bool IsInteresting(Room room)
    {
        if(!HasVisited(room) || RoomPathFind.Freedors(room)) return true;
        return false;
    }

    public bool HasVisited(Room room)
    {
        return visitedRooms.Contains(room);
    }

}
