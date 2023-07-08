using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 targetPoint;
    public bool isWalking;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, Speed * Time.deltaTime);
        }
        
        if(transform.position == targetPoint)
        {
            isWalking = false;
        }
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
