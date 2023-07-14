using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsLocker : MonoBehaviour
{
    public bool IsTileMapLocked;
    public TileManager tileManager;

    private void Start()
    {
        TileMapLock();
    }

    public void TileMapLock()
    {
        if (IsTileMapLocked)
        {
            for (int x = 0; x < tileManager.width; x++)
            {
                for (int y = 0; y < tileManager.height; y++)
                {
                    tileManager.roomSlots[x, y].GetComponent<RoomSlot>().IsLocked = true;
                }
            }
        }
    }
}
