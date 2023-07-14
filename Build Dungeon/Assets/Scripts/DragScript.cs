using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private bool dragging = false;
    public bool canDrag = true;
    private Vector3 offset;
    public TileManager TileManager;
    private GameObject roomSlot;
    private Vector3 primalPos;

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
        primalPos = transform.position;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        if(canDrag) dragging = true;
    }
    private int OnMouseUp()
    {
        if(!dragging) { return -1; }
        Debug.Log(gameObject.name);
        dragging = false;
        int f = 1;
        if (roomSlot != null)
        {
            f = roomSlot.GetComponent<RoomSlot>().AddRoom(gameObject);
        }
        if(f==1)
        {
            transform.position = primalPos;
        }   else { canDrag= false; }
        return 0;
    }
}
