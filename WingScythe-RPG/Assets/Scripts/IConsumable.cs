using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Consumable Interface
 * 
 * Author: Ryan Xu
 * */
public interface IConsumable
{
    void Consume();
    void Consume(PlayerStats stats);
}
