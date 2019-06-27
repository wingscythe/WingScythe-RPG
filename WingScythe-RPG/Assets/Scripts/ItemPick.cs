using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.IO;

public class ItemPick : MonoBehaviour
{
    //Testing 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Item curr = ItemDatabase.Instance.GetItem("potion_test");
            if (File.Exists("./Assets/Resources/Consumables/" + curr.name + ".prefab"))
            {
                Instantiate(Resources.Load("Consumables/" + curr.name) as GameObject);
            }
            else
            {
                Debug.Log("Doesn't Exist");
            }
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
