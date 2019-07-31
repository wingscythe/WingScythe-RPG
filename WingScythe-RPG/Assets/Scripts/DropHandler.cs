﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * This class allows the items to be dragged and dropped(Inventory)
 *
*/
public class DropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    //drag variables
    public Vector2 start;
    public Vector2 switchpos;
    public Transform parent;
    public GameObject pulled;
    public Image img;

    public void Start()
    {
        pulled = item;
        switchpos = img.transform.position;
        Debug.Log(switchpos);
    }
    public GameObject item
    {
        get
        {
            if (transform.childCount < 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    //gets item getting pulled and position
    public void OnBeginDrag(PointerEventData eventData)
    {
        pulled = gameObject;
        start = transform.position;
        parent = transform.parent;
        Debug.Log(parent);  
    }
    //allows getting dragged
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    //returns back to original if cannot be swapped
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position != parent.position)
        {
            if (transform.position.x<img.transform.position.x+2)
            {
                pulled = null;
                transform.position = switchpos;
                img.transform.position = start;
            }
            transform.position = start;
        }

    }

    //swapping wip
    public void OnDrop(PointerEventData eventData)
    {
       
        Debug.Log(this.transform.position);
    }
    


}
