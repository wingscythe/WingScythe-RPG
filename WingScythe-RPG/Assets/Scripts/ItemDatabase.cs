using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
    }

    public Item GetItem(string id)
    {
        if (File.Exists(Application.persistentDataPath + "/" + id + ".wingscythe")) {
            FileStream stream = new FileStream(Application.persistentDataPath + "/" + id + ".wingscythe", FileMode.Open);

            Item item = bf.Deserialize(stream) as Item;
            stream.Close();
            return item;
        }
        return null;
    }

    public void SaveItem(Item save)
    {
        FileStream stream = new FileStream(Application.persistentDataPath + "/" + save.id + ".wingscythe", FileMode.Create);

        bf.Serialize(stream, save);
        stream.Close();
    }
}
