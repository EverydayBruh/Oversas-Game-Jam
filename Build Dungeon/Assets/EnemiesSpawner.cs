using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Список префабов наследников Enemy
    public TileManager tileManager;

    
    private void Start()
    {
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }
    /// <summary>
    /// Инициализация врага на сцене после случайного определения его типа
    /// </summary>
    public GameObject SpawnRandomEnemy(Room room)
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count); // Генерация случайного индекса
        GameObject randomEnemyPrefab = enemyPrefabs[randomIndex]; // Получение случайного префаба

        GameObject Enemy = Instantiate(randomEnemyPrefab, room.transform);
        Enemy.transform.position += new Vector3(randomEnemyPrefab.GetComponent<EnemyScript>().EnemySetPosition().x,randomEnemyPrefab.GetComponent<EnemyScript>().EnemySetPosition().y, 0) * tileManager.distance_multiplier + Vector3.back;
        Debug.Log("EnemyCreated");
        return Enemy;
    }
  
}
