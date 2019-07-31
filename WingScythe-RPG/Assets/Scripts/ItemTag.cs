using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Provides item information for save file and other classes.
 * 
 * Author: Ryan Xu
 * */
public class ItemTag : MonoBehaviour
{
    public string item_name;
    public string id;
    public bool item_mod;
    public string description;
    public List<Stat> stats;
}
