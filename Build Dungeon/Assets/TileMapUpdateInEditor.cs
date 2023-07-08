using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class TileMapUpdateInEditor : MonoBehaviour
{

    private uint last_width = 0;
    private uint last_heaight = 0;
    public TileManager tileManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tileManager.width!= last_width || tileManager.height != last_heaight) 
        {
            Debug.Log("Updated");
            tileManager.UpdateSlots();
            last_heaight= tileManager.height;
            last_width= tileManager.width;
        }
    }
}
