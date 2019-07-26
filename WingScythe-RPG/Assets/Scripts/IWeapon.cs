using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Interface for Weapons
 * 
 * Author: Ryan Xu
 * */
public interface IWeapon
{
    List<Stat> Stats { get; set; }
    void Basic_Attack();
    void Special_Attack(int index);
}
