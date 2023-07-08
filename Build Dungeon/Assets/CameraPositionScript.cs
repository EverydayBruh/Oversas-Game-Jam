using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraPositionScript : MonoBehaviour
{
    public TileManager tileManager;
    public RoomInventory inventory;
    private float level_height;
    private float level_width;

    // Start is called before the first frame update
    void Start()
    {
        CameraRePos();
    }

    public void CameraRePos()
    {
        //Camera Pos
        level_width = (tileManager.width * tileManager.distance_multiplier) / 2f;
        level_height = ((tileManager.height  * tileManager.distance_multiplier - inventory.y_inventoryOffset + (inventory.transform.position.y + 1.5f)) / 2f);
        //Debug.Log("tileManager.height: " + tileManager.height + "\n   tileManager.distance_multiplier: " + tileManager.distance_multiplier + " \n  inventory.y_inventoryOffset: " + inventory.y_inventoryOffset + " \n  inventory.transform.position.y : " + inventory.transform.position.y);
        Camera.main.transform.position = new Vector3(level_width, level_height, -10f);

        //Camera Scale
        Camera.main.orthographicSize = (tileManager.height + 2)/ 0.625f;
    }

}
