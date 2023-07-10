using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // ������ �������� ����������� Enemy
    public TileManager tileManager;

    
    private void Start()
    {
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }
    /// <summary>
    /// ������������� ����� �� ����� ����� ���������� ����������� ��� ����
    /// </summary>
    public GameObject SpawnRandomEnemy(Room room)
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count); // ��������� ���������� �������
        GameObject randomEnemyPrefab = enemyPrefabs[randomIndex]; // ��������� ���������� �������

        GameObject Enemy = Instantiate(randomEnemyPrefab, room.transform);
        Enemy.transform.position += new Vector3(randomEnemyPrefab.GetComponent<EnemyScript>().EnemySetPosition().x,randomEnemyPrefab.GetComponent<EnemyScript>().EnemySetPosition().y, 0) * tileManager.distance_multiplier + Vector3.back;
        Debug.Log("EnemyCreated");
        return Enemy;
    }
  
}
