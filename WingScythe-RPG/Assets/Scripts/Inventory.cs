using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public CanvasGroup inven;
    public Component[] image = new Component[10];
    public Button invent;
    public float time = 0;
    private int i = 0;
    private Color orig;
    // Update is called once per frame
    private void Start()
    {
        orig = image[i].GetComponent<Image>().color;
        invent.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        if (inven.alpha == 1f)
        {
            if (Math.Floor(counter()) % 2 == 0) image[i].GetComponent<Image>().color = Color.red;
            else if (Math.Floor(counter()) % 2 == 1) image[i].GetComponent<Image>().color = orig;
            if (Input.GetKeyDown(KeyCode.D) && i < 9)
            {
                image[i].GetComponent<Image>().color = orig;
                i++;
            }
            if (Input.GetKeyDown(KeyCode.A) && i > 0)
            {
                image[i].GetComponent<Image>().color = orig;
                i--;
            }
        }
    }
    void TaskOnClick()
    {
        if (inven.alpha == 0f)
        {
            inven.alpha = 1f;
            inven.interactable = true;
            inven.blocksRaycasts = true;
        }
        else if (inven.alpha == 1f)
        {
            inven.alpha = 0f;
            inven.interactable = false;
            inven.blocksRaycasts = false;
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

