using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeisSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // ������ �������� ����������� Enemy

    /// <summary>
    /// ������������� ����� �� ����� ����� ���������� ����������� ��� ����
    /// </summary>
    public void SpawnRandomEnemy(Room room)
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count); // ��������� ���������� �������
        GameObject randomEnemyPrefab = enemyPrefabs[randomIndex]; // ��������� ���������� �������

        Instantiate(randomEnemyPrefab, randomEnemyPrefab.GetComponent<EnemyScript>().EnemySetPosition(room), Quaternion.identity, room.transform);
        Debug.Log("EnemyCreated");
    }
  
}
