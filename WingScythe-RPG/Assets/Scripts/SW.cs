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
    public IWeapon ws;
    public bool slot;
    public Button attack;
    public Button spAtk1;
    public Button spAtk2;
    public Button spAtk3;
    // Start is called before the first frame update
    void Start()
    {
        weapon1 = hero.transform.GetChild(0).gameObject;
        weapon2 = hero.transform.GetChild(1).gameObject;

        slot = true;
        weapon = weapon1;
        ws = weapon.GetComponent<IWeapon>();
        sw.onClick.AddListener(TaskOnClick);
        attack.onClick.AddListener(Basic);
        spAtk1.onClick.AddListener(SpAtk1);
        spAtk2.onClick.AddListener(SpAtk2);
        spAtk3.onClick.AddListener(SpAtk3);
    }

    //switch weapon button
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
        ws = weapon.GetComponent<IWeapon>();
        slot = !slot;
        swapWeapon();
    }

    public void swapWeapon()
    {
        weapon1.SetActive(slot);
        weapon2.SetActive(!slot);
    }

    //special attacks built into buttons
    public void Basic()
    {
        ws.Basic_Attack();
    }

    public void SpAtk1()
    {
        PlayerSpecialAttack(1);
    }

    public void SpAtk2()
    {
        PlayerSpecialAttack(2);
    }

    public void SpAtk3()
    {
        PlayerSpecialAttack(3);
    }

    private void PlayerSpecialAttack(int index)
    {
        ws.Special_Attack(index);
    }
}

