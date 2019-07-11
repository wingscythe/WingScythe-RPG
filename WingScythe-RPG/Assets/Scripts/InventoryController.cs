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
    }

    public void GiveItem(string id)
    {
        items.Add(ItemDatabase.Instance.GetItem(id));
    }

    public void SetItemDetails(Item item, Button b)
    {
        //TODO: set item information
    }
}
