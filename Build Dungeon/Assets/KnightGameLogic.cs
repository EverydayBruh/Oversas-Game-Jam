using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightGameLogic : MonoBehaviour
{
    public GameObject spawnRoom;
    public GameObject curRoom;
    private KnightScript knight;

    private void Awake()
    {
        knight = GetComponent<KnightScript>();
    }
    void Start()
    {
        curRoom = spawnRoom;
        knight.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
