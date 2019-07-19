using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item item;
    public string item_text;
    public Sprite item_image;

    public void SetItem(Item item)
    {
        this.item = item;
        item_text = item.name;
        item_image = Resources.Load<Sprite>("UI/Items/" + item.id);
        Image img = GetComponent<Image>();
        img.sprite = item_image;
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}
