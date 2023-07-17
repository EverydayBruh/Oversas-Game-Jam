using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FightLogic: MonoBehaviour
{

    //public static void StartFight(List<Entity> sideA, List<Entity> sideB)
    //{
    //    this.StartCoroutine(FightCoroutine(sideA, sideB));
    //}
    static public IEnumerator FightCoroutine(List<Entity> sideA, List<Entity> sideB, Action onComplete)
    {
        foreach(Entity ent in sideA) { Debug.Log(ent.name); }
        foreach (Entity ent in sideB) { Debug.Log(ent.name); }
        // Бесконечный цикл боя, пока есть живые сущности на обеих сторонах
        while (sideA.Count > 0 && sideB.Count > 0)
        {
            // Атака каждой сущности из sideA
            foreach (Entity entityA in sideA)
            {
                if (sideB.Count == 0)
                    break; // Все сущности из sideB уже погибли, прекратить атаку

                

                entityA.Attack(sideB);
                sideB.RemoveAll(entity => !entity.IsAlive);
                yield return new WaitForSeconds(entityA.attackDelay); // Задержка после атаки
            }

            // Удаление погибших сущностей из sideA и sideB

            foreach (Entity entityB in sideB)
            {
                if (sideA.Count == 0)
                    break; // Все сущности из sideB уже погибли, прекратить атаку



                sideA.RemoveAll(entity => !entity.IsAlive);
                entityB.Attack(sideA);
                yield return new WaitForSeconds(entityB.attackDelay); // Задержка после атаки
            }


            yield return null; // Подождать один кадр перед следующим шагом боя
        }
        Debug.Log("Fight Ended");
        onComplete?.Invoke();
    }



}
