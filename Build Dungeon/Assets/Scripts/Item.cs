using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool PickUpable = false;
    public string Name;
    //public void Attack()  { }
    //public void Defense()  { }
    //public void WTF()   { }
}
public interface IWeapon
{
    void Weapon(int damage);
}
public interface IArmor
{
    void Armor(int def);
}
public interface IArtifact
{
    void Artifact();
}

public class PISYAPOPA : Item, IWeapon
{
    public void Weapon(int damage)
    {
        //Attack();
        //лнфер ршююл сахрэ бяеу пюганрвхйнб х ху люрепеи;
    }
}
public class CHLEEEEEEEEN : Item, IArmor, IWeapon
{
    public void Armor(int def)
    {
        //ухкхряъ мю лхккхнм уо ю онрнл слхпюер;
    }
    public void Weapon(int damage)
    {

    }
}