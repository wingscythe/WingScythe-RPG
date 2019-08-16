using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
 * Controls the Item Database
 * 
 * Author: Ryan Xu
 * */
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }

    private BinaryFormatter bf = new BinaryFormatter();

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
        Debug.Log("Database Initialized! Time: " + Time.fixedTime);
    }

    public Item GetItem(string id)
    {
        if (File.Exists("./Assets/Resources/ItemData/" + id + ".wingscythe")) {
            FileStream stream = new FileStream("./Assets/Resources/ItemData/" + id + ".wingscythe", FileMode.Open);
            Item item = bf.Deserialize(stream) as Item;
            stream.Close();
            return item;
        }
        Debug.Log("failed, doesn't exist");
        return null;
    }

    public void SaveItem(Item save)
    {
        //Ryan Note: Might have to tweak this for weapons and consumables, maybe like a type identifier on top of an ID save.
        FileStream stream = new FileStream("./Assets/Resources/ItemData/" + save.id + ".wingscythe", FileMode.Create);

        bf.Serialize(stream, save);
        stream.Close();
        Debug.Log("Item Saved!");
    }
}
