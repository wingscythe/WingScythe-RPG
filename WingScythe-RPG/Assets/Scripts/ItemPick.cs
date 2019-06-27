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
            Instantiate<GameObject>(Resources.Load("/Consumables/" + curr.name, typeof(GameObject)) as GameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "item")
        {
            //New Item Manual Save:

            /*
            ItemTag it = other.gameObject.GetComponent<ItemTag>();
            Item item = new Item(it.item_name, it.id, it.description);
            ItemDatabase.Instance.SaveItem(item);
            */

            //Add sprite and id to inventory.

            Destroy(other.gameObject);
        }
    }
}
