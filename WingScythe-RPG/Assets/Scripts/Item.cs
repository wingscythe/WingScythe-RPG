using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public string name { get; set; }
    public string id { get; set; }
    public bool item_mod { get; set; }
    public string description { get; set; }
    public List<Stat> stats { get; set; }

    public Item(string init_name, string init_id, string init_desc)
    {
        name = init_name;
        id = init_id;
        description = init_desc;
        item_mod = false;
    }
}
