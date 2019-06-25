using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SW : MonoBehaviour
{
    public Button sw;
    public GameObject hero;
    public GameObject weapon1;
    public GameObject weapon2;

    public GameObject weapon;
    public Weapon ws;
    public bool slot;
    // Start is called before the first frame update
    void Start()
    {
        weapon1 = hero.transform.GetChild(0).gameObject;
        weapon2 = hero.transform.GetChild(1).gameObject;

        slot = true;
        weapon = weapon1;
        ws = weapon.GetComponent<Weapon>();
        sw.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (slot)
        {
            weapon = weapon2;
        }
        else
        {
            weapon = weapon1;
        }
        ws = weapon.GetComponent<Weapon>();
        slot = !slot;
        swapWeapon();
    }

    public void swapWeapon()
    {
        weapon1.SetActive(slot);
        weapon2.SetActive(!slot);
    }
}
