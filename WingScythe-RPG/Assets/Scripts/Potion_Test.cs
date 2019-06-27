using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
