using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    //Fix This to IWeapons or something later.
    [Header("Weapon Attributes")]
    public GameObject weapon1;
    public GameObject weapon2;

    public GameObject weapon;
    public IWeapon ws;

    [Space]

    [Header("Player Settings")]
    public bool slot;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Get initial weapons from metadata

        //TODO: Do initialization
        weapon1 = transform.GetChild(0).gameObject;
        weapon2 = transform.GetChild(1).gameObject;

        slot = true;
        weapon = weapon1;
        ws = weapon.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keypress Swap
        if (Input.GetKeyDown(KeyCode.X))
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

        //Weapon Attacks
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerBasicAttack();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerSpecialAttack(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerSpecialAttack(2);
        }
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            PlayerSpecialAttack(3);
        }
    }

    public void swapWeapon()
    {
        weapon1.SetActive(slot);
        weapon2.SetActive(!slot);
    }

    public void EquipWeapon(GameObject new_weap)
    {
        //If the character has no weapon, instantly equip weapon
        if(weapon1 == null)
        {
            instant_replace(weapon1, new_weap);
            return;
        }

        //Since old weapon exists, first try second slot
        if(weapon2 == null)
        {
            instant_replace(weapon2, new_weap);
        }

        //Since both weapons exist, replace currently equipped weapon
        if (slot)
        { 
            //TODO: place old weapon in slot 1 in inventory.

            //Now that hand is empty, instantly replace
            instant_replace(weapon1, new_weap);
        }
        else
        { 
            //TODO: place old weapon in slot 2 in inventory.

            //Now that hand is empty, instantly replace
            instant_replace(weapon2, new_weap);
        }
    }

    //Instantly replaces the given weapon slot with the new weapon.
    //WARNING: Any weapon that remained in given weapon_slot will be lost.
    private void instant_replace(GameObject weapon_slot, GameObject new_weap)
    {
        weapon_slot = new_weap;
        weapon = new_weap;
        //TODO: Do initialization
        return;
    }

    private void PlayerBasicAttack()
    {
        ws.Basic_Attack();
    }

    private void PlayerSpecialAttack(int index)
    {
        ws.Special_Attack(index);
    }
}
