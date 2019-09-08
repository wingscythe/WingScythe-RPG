using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NOTE: UNFINISHED, NEEDS TESTING. 
 * 
 * 
 */
public class ItemDropTable : MonoBehaviour
{
    public List<ItemDrop> loot;

    public Item GetDrop()
    {
        int rng = Random.Range(0, 101);
        int totalWeight = 0;
        foreach (ItemDrop x in loot)
        {
            totalWeight += x.weight;
            if(rng < totalWeight)
            {
                return ItemDatabase.Instance.GetItem(x.id);
            }
        }
        return null;
    }
}

public class ItemDrop
{
    public string id { get; set; }
    public int weight { get; set; }

    public ItemDrop(string init_id, int init_weight)
    {
        id = init_id;
        weight = init_weight;
    }
}
