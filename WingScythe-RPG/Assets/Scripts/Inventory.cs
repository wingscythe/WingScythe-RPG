using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public CanvasGroup inven;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inven.alpha == 0f)
        {
            inven.alpha = 1f;
            inven.interactable = true;
            inven.blocksRaycasts = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && inven.alpha == 1f)
        {
            inven.alpha = 0f;
            inven.interactable = false;
            inven.blocksRaycasts = false;
        }
        
    }
}

