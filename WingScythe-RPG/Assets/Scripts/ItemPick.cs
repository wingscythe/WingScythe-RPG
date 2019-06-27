using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "item")
        {
            //Inventory.addItems(other.gameObject);  
            Destroy(other.gameObject);
        }
    }
}
