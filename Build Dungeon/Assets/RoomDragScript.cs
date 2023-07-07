using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDragScript : MonoBehaviour
{
    public Vector3 objPosition;

    private void Start()
    {
        objPosition = transform.position;
    }
    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    private void OnMouseDrag()
    {      
        this.transform.position = GetMousePosition();
    }
    private void OnMouseUp()
    {
        transform.position = objPosition;
    }
}
