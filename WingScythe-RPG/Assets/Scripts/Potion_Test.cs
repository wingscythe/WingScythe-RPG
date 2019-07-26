using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Potion Consumable for testing purposes. 
 * 
 * Author: Ryan Xu
 * */
public class Potion_Test : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("Consumed!");
    }

    public void Consume(PlayerStats stats)
    {
        Debug.Log("Consumed, but nothing happens to the player!");
    }
}
