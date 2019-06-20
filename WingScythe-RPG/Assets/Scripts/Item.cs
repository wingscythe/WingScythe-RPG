using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [Header("Item Attributes")]
    protected string item_name = null;
    protected string type = null;
    protected GameObject item = null;

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

    public string getItemName()
    {
        return item_name;
    }

    public string getType()
    {
        return type;
    }
    public GameObject getitem()
    {
        return item;
    }

    public abstract void Consume();
    public abstract void Basic_Attack();
    public abstract void Special_Attack(int index);
    public abstract void DoubleClick();
}
