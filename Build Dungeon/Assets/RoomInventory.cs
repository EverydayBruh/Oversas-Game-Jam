using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class RoomInventory : MonoBehaviour
{
    private Room[] RoomsInventory;
    public Room room;
    public int RoomInventoryCapacity = 7;
    public float distance_multiplier = 3f;

    void Start()
    {
        UpdateRoomInventory();
    }
    public void UpdateRoomInventory()
    {
        RoomsInventory = new Room[RoomInventoryCapacity];

        for (int x = 0; x < RoomInventoryCapacity; x++)
        {
            if (RoomsInventory[x] == null)
            {               
                Vector3 pos = transform.position + new Vector3(x - (RoomInventoryCapacity/2), 0) * distance_multiplier;
                RoomsInventory[x] = Instantiate(room, pos, new Quaternion(), this.transform);
                //RoomsInventory[x].GetComponent<Room>().SetCoordinates(new Vector2(pos.x,0));
                RoomsInventory[x].GetComponent<Room>().Randomise();
                Debug.Log("Room Created");
            }
        }
    }

}
