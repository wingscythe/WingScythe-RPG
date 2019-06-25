using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Weapon : MonoBehaviour, IWeapon
{ 
    [Header("Weapon Attributes")]
    public string item_name;
    public int attack_counter;
    public float cooldown;
    public float RESET = 2f;

    [Space]

    [Header("Spear Attributes")]
    public int range;
    private Animator animator;

    /*
    [Space]

    [Header("Stats")]
    public float STR = 0;
    public float DEF = 0;
    public float INT = 0;
    public float AGI = 0;
    public float DEX = 0;
    public float LUC = 0;
    public float WHT = 0;
    */
    public List<Stat> Stats { get; set; }

    //Stats

    // Start is called before the first frame update
    void Start()
    {
        attack_counter = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if(RESET > 0)
        {
            RESET -= Time.deltaTime;
        }
        if (RESET <= 0)
        {
            attack_counter = 0;
            animator.SetInteger("Attack", attack_counter);
            animator.SetBool("Basic_Attack", false);
            animator.SetBool("Special_Attack_1", false);
            animator.SetBool("Special_Attack_2", false);
            animator.SetBool("Special_Attack_3", false);
        }
    }

    public void Basic_Attack()
    {
        if(cooldown > 0)
        {
            //TODO: Grey out and fill button
            return;
        }

        cooldown += 1f;
        animator.SetBool("Basic_Attack",true);
        attack_counter++;
        animator.SetInteger("Attack", attack_counter);
        if (attack_counter < 3)
        {
            RESET = 2f;
        }
    }

    public void Special_Attack(int index)
    {
        cooldown += 1f;
        animator.SetBool("Special_Attack_" + index, true);
        attack_counter++;
        animator.SetInteger("Attack", attack_counter);
        if (attack_counter < 3)
        {
            RESET = 2f;
        }
    }

    public void Consume()
    {
        throw new System.NotImplementedException();
    }

    public void DoubleClick()
    {
        //TODO: Equip Weap
    }

    public static implicit operator Weapon(GameObject v)
    {
        throw new NotImplementedException();
    }
}
