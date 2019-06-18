using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Item Attributes")]
    public string item_name;
    public string type;
    public GameObject item;

    [Space]

    [Header("Consumables, Misc, Etc.")]
    public int quantity = -1;

    public static Item operator --(Item item)
    {
        if(item!=null && item.type != "weapon") {
            item.quantity--;
        }
        return item;
    }

    public abstract void Consume();
    public abstract void Basic_Attack();
    public abstract void Special_Attack(int index);
}
