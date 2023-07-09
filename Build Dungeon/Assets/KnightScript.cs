using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 targetPoint;
    public bool isWalking;


    [Header("Player Animation Settings")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isWalking == true)
        {
            animator.SetBool("isStaying", false);
            animator.SetFloat("HorizontalMovement", transform.position.x - targetPoint.x); // ¬право или влево
            animator.SetFloat("VerticalMovement", Mathf.Abs(transform.position.y - targetPoint.y)); // ¬верх или вниз
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Speed * Time.deltaTime);
        }
        
        if(transform.position == targetPoint)
        {
            animator.SetBool("isStaying", true); // ¬право или влево
            isWalking = false;
        }
    }
   public void MoveToRoom(Room room)
    {
        MoveToPoint(room.KnightPos());
    }
    
    public void MoveToPoint(Vector3 targetPoint)
    {
        this.targetPoint = targetPoint;
        isWalking = true;
    }

    public void GetItem(GameObject item)
    {
        item.transform.parent = gameObject.transform;
    }
}
