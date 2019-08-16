using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public PlayerWeaponController pwc;
    public PlayerConsume pc;
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        pwc = GetComponent<PlayerWeaponController>();
        pc = GetComponent<PlayerConsume>();

        GiveItem("spear");
        GiveItem("potion_test");
    }
       
    /*
     * Adds given item to player inventory using the item's ID
     * 
     * Author: Ryan Xu
     */
    public void GiveItem(string id)
    {
        Item item = ItemDatabase.Instance.GetItem(id);
        if(item !=  null)
        {
            items.Add(item);
            UIEventHandler.ItemAddedToInventory(item);
        }
        else
        {
            Debug.Log("Item is NULL");
        }
    }

    public void SetItemDetails(Item item, Button b)
    {
        //TODO: set item information
    }
}
