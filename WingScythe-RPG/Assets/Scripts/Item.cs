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
}
