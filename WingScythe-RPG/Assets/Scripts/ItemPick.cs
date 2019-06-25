using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("smth");
        if (other.tag == "Consumable")
        {
            Debug.Log("hit");
        }
    }
}
