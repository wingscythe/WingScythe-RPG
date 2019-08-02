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

    public List<Image> img;
    public List<Vector2> positions;

    public void Start()
    {
        pulled = item;
        for (int i = 0; i < img.Count; i++)
        {
            positions.Add(img[i].transform.position);
        }
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
        start = pulled.transform.position;
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
            for(int i = 0; i < img.Count; i++)
            {
                if (img[i].transform.position.x + 2 < transform.position.x)
                {
                    pulled = null;
                    transform.position = img[i].transform.position;
                    img[i].transform.position = start;
                    break;
                }
            }
        }
        transform.position = start;

    }

    //swapping wip
    public void OnDrop(PointerEventData eventData)
    {
       
        Debug.Log(this.transform.position);
    }
    


}
