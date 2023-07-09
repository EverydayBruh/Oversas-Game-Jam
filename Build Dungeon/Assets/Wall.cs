using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class Wall : MonoBehaviour
{
    public bool haveDoor = false;
    public bool isExit = false;
    public Sprite no_door;
    public Sprite door;
    public Sprite exit;

    public SpriteRenderer spriteRenderer;

    //private void OnValidate()
    //{
    //    UpdateSprite();
    //}


    public void UpdateSprite()
    {
        if (haveDoor)
        {
            if(isExit) spriteRenderer.sprite = exit;
            else spriteRenderer.sprite = door;
        }
        else
        {
            spriteRenderer.sprite = no_door;
        }
    }

    public void AddDoor()
    {
        haveDoor = true;
        UpdateSprite();
    }

    public void DeleteDoor()
    {
        haveDoor = false;
        UpdateSprite();
    }
}
