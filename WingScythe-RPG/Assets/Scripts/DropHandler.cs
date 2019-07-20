﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    //drag variables
    public Vector2 start;
    public Transform parent;
    public GameObject pulled;

   /* public void Start()
    {
        pulled = item;
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
    public void OnBeginDrag(PointerEventData eventData)
    {
        pulled = gameObject;
        start = transform.position;
        parent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        pulled = null;
        if(transform.position!= parent.position)transform.position = start;

    }

    //swapping wip
    public void OnDrop(PointerEventData eventData)
    {
        if(!item)pulled.transform.SetParent(transform);
    }
    */


}