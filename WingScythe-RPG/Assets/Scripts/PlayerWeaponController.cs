using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("Weapon Attributes")]
    public Item weapon1;
    public Item weapon2;

    [Space]

    [Header("Player Settings")]
    public bool slot;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Get initial weapons from metadata

        //TODO: Do initialization
        weapon1 = Spear.CreateInstance<Spear>();
        weapon2 = Spear.CreateInstance<Spear>();


        slot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Keypress Swap
        if (Input.GetKeyDown(KeyCode.X))
        {
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
        transform.GetChild(0).gameObject.SetActive(slot);
        transform.GetChild(1).gameObject.SetActive(!slot);
    }

    public void EquipWeapon(Item new_weap)
    {
        //Check if the item is a weapon
        if(new_weap.getType() != "weapon")
        {
            //Print error message
            return;
        }

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
    private void instant_replace(Item weapon_slot, Item new_weap)
    {
        weapon2 = new_weap;
        //TODO: Do initialization
        return;
    }

    private void PlayerBasicAttack()
    {
        if (slot)
        {
            //weapon1.Basic_Attack();
        }
        else
        {
            //weapon2.Basic_Attack();
        }
    }

    private void PlayerSpecialAttack(int index)
    {
        if (slot)
        {
            //weapon1.Special_Attack(index);
        }
        else
        {
            //weapon2.Special_Attack(index);
        }
    }
}
