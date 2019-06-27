using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    //Testing 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Item curr = ItemDatabase.Instance.GetItem("potion_test");
            Debug.Log(curr.name);
            Debug.Log(curr.id);
            Debug.Log(curr.description);
            Debug.Log(curr.stats);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "item")
        {
            ItemTag it = other.gameObject.GetComponent<ItemTag>();
            Item item = new Item(it.item_name, it.id, it.description);
            ItemDatabase.Instance.SaveItem(item);
            Destroy(other.gameObject);
        }
    }
}
