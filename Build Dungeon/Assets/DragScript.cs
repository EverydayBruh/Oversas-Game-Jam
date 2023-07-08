using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    public TileManager TileManager;
    private GameObject roomSlot;

    void Start()
    {
        TileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }

    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            roomSlot = TileManager.GetRoomSlot(transform.position);          
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        dragging = true;
    }
    private void OnMouseUp()
    {
        if (roomSlot != null)
        {
            Destroy(roomSlot);
        }
        dragging = false;
    }
}
