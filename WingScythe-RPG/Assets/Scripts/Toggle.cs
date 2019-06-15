using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public Button toggle;
    public CanvasGroup attack;
    public CanvasGroup moves;
    private void Start()
    {
        toggle.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (attack.alpha == 1f || moves.alpha == 0f)
        {
            attack.alpha = 0f;
            attack.interactable = false;
            attack.blocksRaycasts = false;
            moves.alpha = 1f;
            moves.interactable = true;
            moves.blocksRaycasts = true;
        }
        else if(moves.alpha == 1f || attack.alpha == 0f)
        {
            moves.alpha = 0f;
            moves.interactable = false;
            moves.blocksRaycasts = false;
            attack.alpha = 1f;
            attack.interactable = true;
            attack.blocksRaycasts = true;
        }
    }

}
