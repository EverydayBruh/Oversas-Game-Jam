using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public TileManager TileManager;
    private Vector3 worldPosition;
    private GameObject roomSlot;
    void Start()
    {
        //Destroy(TileManager.ObjSlotByCoord(1, 1));
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        this.transform.position = worldPosition;

        roomSlot = TileManager.GetRoomSlot(worldPosition);
        if (roomSlot != null)
        {
            Destroy(roomSlot);
        }
    }
}
