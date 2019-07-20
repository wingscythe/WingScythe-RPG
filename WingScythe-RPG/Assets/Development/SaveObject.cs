using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class manually saves any item by keypress. This is in order to make template objects in saved data files.
 * 
 * Author: Ryan Xu
 * 
 * Authors Note:
 * Things to do after saving:
 * -Update UI icon
 * 
 * */
public class SaveObject : MonoBehaviour
{
    ItemTag data;

    private void Start()
    {
        data = GetComponent<ItemTag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Item save = new Item(data.name, data.id, data.description);
            if (data.item_mod != false)
            {
                save.item_mod = true;
            }
            if(data.stats != null)
            {
                save.stats = data.stats;
            }
            ItemDatabase.Instance.SaveItem(save);
        }
    }
}
