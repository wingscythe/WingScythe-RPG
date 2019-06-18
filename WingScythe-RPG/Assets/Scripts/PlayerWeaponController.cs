using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("Weapon Attributes")]
    public Item weapon;
    public Item weapon2;

    [Space]

    [Header("Player Settings")]
    public bool slot;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Get initial weapons from metadata

        //TODO: Do initialization
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
    }

    public void swapWeapon()
    {
        transform.GetChild(0).gameObject.SetActive(slot);
        transform.GetChild(1).gameObject.SetActive(!slot);
    }

    public void EquipWeapon(Item new_weap)
    {
        //Check if the item is a weapon
        if(new_weap.type != "weapon")
        {
            //Print error message
            return;
        }

        //If the character has no weapon, instantly equip weapon
        if(weapon == null)
        {
            instant_replace(weapon, new_weap);
            return;
        }

        //Since old weapon exists, first try second slot
        if(weapon2 == null)
        {
            instant_replace(weapon, new_weap);
        }

        //Since both weapons exist, replace currently equipped weapon
        if (slot)
        { 
            //TODO: place old weapon in slot 1 in inventory.

            //Now that hand is empty, instantly replace
            instant_replace(weapon, new_weap);
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
    void instant_replace(Item weapon_slot, Item new_weap)
    {
        weapon2 = new_weap;
        //TODO: Do initialization
        return;
    }
}
