using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //Empty Container for duplication
    InventoryItem itemContainer { get; set; }

    //List of UI Items
    List<InventoryItem> itemUIList = new List<InventoryItem>();

    //Size of the inventory TODO: Think about what happens if we expand past set amount
    public static int size;

    //UNSORTED:
    public CanvasGroup inven;
    public CanvasGroup joy;
    public Component[] image = new Component[10];
    public Button invent;
    public GameObject hero;
    public float time = 0;
    private int i = 0;
    private Color orig;
    private GameObject item;
    // Update is called once per frame
    private void Start()
    {
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        itemContainer = Resources.Load<InventoryItem>("UI/ItemContainer"); //TODO: ASK @Jeff about container

        //Unsorted Section:
        size = 10;
        orig = image[i].GetComponent<Image>().color;
        invent.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        //if inventory is present flashes colors
        if (inven.alpha == 1f)
        {
            joy.interactable = false;
            joy.blocksRaycasts = false;
            if (Math.Floor(counter()) % 2 == 0) image[i].GetComponent<Image>().color = Color.red;
            else if (Math.Floor(counter()) % 2 == 1) image[i].GetComponent<Image>().color = orig;
            if (Input.GetKeyDown(KeyCode.D) && i < 9)
            {
                image[i].GetComponent<Image>().color = orig;
                i++;
            }
            if (Input.GetKeyDown(KeyCode.A) && i > 0) // change left and right
            {
                image[i].GetComponent<Image>().color = orig;
                i--;
            }
        }
    }

    public void ItemAdded(Item item)
    {
        InventoryItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        itemUIList.Add(emptyItem);
        //TODO: emptyItem.transform.SetParent();
    }

    //TODO: Ask @Jeff about using SetActive instead. Not sure about implications of both methods.
    void TaskOnClick()
    {
        //if inventory button is clicked, inventory pops up and joystick is disabled
        if (inven.alpha == 0f)
        {
            inven.alpha = 1f;
            inven.interactable = true;
            inven.blocksRaycasts = true;
        }
        else if (inven.alpha == 1f)
        {
            image[i].GetComponent<Image>().color = orig;
            inven.alpha = 0f;
            inven.interactable = false;
            inven.blocksRaycasts = false;
            joy.interactable = true;
            joy.blocksRaycasts = true;
            i = 0;
            counter();
        }   
    }
    float counter()
    {
        time += Time.deltaTime;
        return time;
    }
}

/* OLD CODE FOR BACKUP:
    //add items to inventory when picked up
    public static void addItems(Item item)
    {
        if (items.Count < size)
        {
            items.Add(item);
            Debug.Log(item.name + " was added");
        }
        else
        {
            //TODO: Error statement, inventory full.
            return;
        }
    }

    //return list of items
    public List<Item> getItems()
    {
        return items;

    }

    //how big inventory is
    public int getSize()
    {

        return size;
    }

    //upgrade size 
    public void addSize(int n)
    {
        size += n;
    }
    */
