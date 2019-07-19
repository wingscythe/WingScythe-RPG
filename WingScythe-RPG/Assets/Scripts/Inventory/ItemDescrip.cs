using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescrip : MonoBehaviour
{
    private Item item;
    private string input;
    private GameObject descrip;
    void Start()
    {
        descrip = GameObject.Find("Descrip");
        
    }

    public void Initialize(Item item)
    {
        this.item = item;
        CreateString();
        descrip.SetActive(true);
    }

    public void Close()
    {
        descrip.SetActive(false);
    }

    public void CreateString()
    {
        if (input == null)
        {
            input = text();
        }

    }

    public string text()
    {
        return item.description;
    }


}
