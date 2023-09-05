using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class KnightScript : Entity
{
    public float Speed = 10;
    public Vector3 targetPoint;
    public bool isWalking;
    private Inventory inventory;


    [Header("Player Animation Settings")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        Bomb booba = new Bomb(); 
        inventory.items.Add(booba);
        booba.owner = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isWalking == true)
        {
            animator.SetBool("isStaying", false);
            animator.SetFloat("HorizontalMovement", transform.position.x - targetPoint.x); // ������ ��� �����
            animator.SetFloat("VerticalMovement", Mathf.Abs(transform.position.y - targetPoint.y)); // ����� ��� ����
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Speed * Time.deltaTime);
        }
        
        if(transform.position == targetPoint)
        {
            animator.SetBool("isStaying", true); // ������ ��� �����
            isWalking = false;
        }
    }
    //���� � �������
   public void MoveToRoom(Room room)
    {
        MoveToPoint(room.KnightPos());
    }
    
    //���� � �����
    public void MoveToPoint(Vector3 targetPoint)
    {
        this.targetPoint = targetPoint;
        isWalking = true;
    }

    public void GetItem(GameObject item)
    {
        item.transform.parent = gameObject.transform;
    }

    public override void Attack(List<Entity> victims)
    {
        foreach(Item item in inventory.items)
        {
            if (item is IWeapon weapon)
            {
                // �������� ����� Attack ��� ��������, ������������ ��������� IWeapon
                weapon.Attack(victims);
            }
        }
        if(inventory.items.Count == 0)
        { 
            Attack(victims[0]); 
        }
        
        //��������� ��������
    }

    public override void TakeDamage(int damage, Entity source)
    {
        base.TakeDamage(damage, source);
        //�������� ��������� �����
    }
}
