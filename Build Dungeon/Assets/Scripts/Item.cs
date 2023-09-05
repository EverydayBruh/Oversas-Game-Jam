using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Entity owner;
    public bool PickUpable = false;
    public string Name;
}
public interface IWeapon
{
    void Attack(List<Entity> victims);
}
public interface IArmor
{
    void Defense();
}
public interface IArtifact
{
    void WTF(List<Entity> victims);
}

public class Bomb : Item, IWeapon
{
    public void Attack(List<Entity> victims)
    {
        foreach (Entity entity in victims)
        {
            entity.TakeDamage(2, owner);
        }
    }
}
public class Sword : Item, IWeapon
{
    public void Attack(List<Entity> victims)
    {
        victims[Random.Range(0, victims.Count)].TakeDamage(3, owner);
    }
    public void WTF(List<Entity> victims)
    {

    }
}