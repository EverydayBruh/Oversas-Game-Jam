using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSlot : MonoBehaviour
{
    public bool IsEmpty = true;
    public bool IsLocked = false;
    private GameObject reference;
    public GameObject room = null;
    public Vector2 coordinates= Vector2.zero;
    private Animator anim;


    //public RoomSlot(Vector2 coordinates, GameObject preafab, GameObject parent)
    //{
    //    Debug.Log("Created");
    //    this.coordinates = coordinates;
    //    Transform trans = preafab.transform;
    //    trans.position = coordinates;
    //    reference = Instantiate(preafab, trans);
    //    reference.transform.parent = parent.transform;
    //}
    private void Start()
    {
        anim = GetComponent<Animator>();
        UpdateRoom();
    }

    public int AddRoom(GameObject newroom)
    {
        if(!IsEmpty || IsLocked) return 1;
        IsEmpty= false;
        room = newroom;
        room.GetComponent<Room>().Place(coordinates, this.transform.position);
        Lock();
        return 0;
    }

    [ContextMenu("Update Room")]
    public int UpdateRoom()
    {
        if (room == null)
        {
            IsEmpty = true;
            return -1;
        }
        IsEmpty = false;
        room.GetComponent<Room>().Place(coordinates, this.transform.position);
        return 0;
    }
    public Room GetRoom()
    {
        if(room == null) return null;
        return room.GetComponent<Room>();
    } 

    public void SetCoordinates(Vector2 coordinates)
    {
        this.coordinates= coordinates;
    }
    public void RoomClear()
    {
        Debug.Log("Cleared");
        if (reference) Destroy(reference);
    }

    public void Lock()
    {
        anim.SetBool("Play", false);
        anim.enabled = false;
        IsLocked = true;
    }

    public void Unlock()
    {
        IsLocked = false;
        anim.SetBool("Play", true);
    }
    ~RoomSlot()
    {
        if(reference) Destroy(reference);
    }
}
