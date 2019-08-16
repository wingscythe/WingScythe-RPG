using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enables the player to use consumables.
 * 
 * Author: Ryan Xu
 * */
public class PlayerConsume : MonoBehaviour
{
    PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    /*
     * Consumes a given item | Parameter: Item item - given item 
     * 
     * Author: Ryan Xu
     **/
    public void ConsumeItem(Item item)
    {
        GameObject itemSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.name));
        if (item.item_mod)
        {
            itemSpawn.GetComponent<IConsumable>().Consume(stats);
        } else {
            itemSpawn.GetComponent<IConsumable>().Consume();
        }
    }
    
}
