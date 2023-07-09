using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeisSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Список префабов наследников Enemy

    /// <summary>
    /// Инициализация врага на сцене после случайного определения его типа
    /// </summary>
    public void SpawnRandomEnemy(Room room)
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count); // Генерация случайного индекса
        GameObject randomEnemyPrefab = enemyPrefabs[randomIndex]; // Получение случайного префаба

        Instantiate(randomEnemyPrefab, randomEnemyPrefab.GetComponent<EnemyScript>().EnemySetPosition(room), Quaternion.identity, room.transform);
        Debug.Log("EnemyCreated");
    }
  
}
