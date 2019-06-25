using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Test : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        print("Consumed!");
    }

    public void Consume(PlayerStats stats)
    {
        print("Consumed, but nothing happens to the player!");
    }
}
