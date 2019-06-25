using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConsume : MonoBehaviour
{
    PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

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
