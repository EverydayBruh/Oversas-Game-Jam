using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Wall : MonoBehaviour
{
    public bool haveDoor = false;
    public Sprite no_door;
    public Sprite door;

    public SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        UpdateSprite();
    }


    private void UpdateSprite()
    {
        if (haveDoor)
        {
            spriteRenderer.sprite = door;
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
