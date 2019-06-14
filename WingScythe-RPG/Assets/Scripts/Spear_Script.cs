using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Script : MonoBehaviour
{
    [Header("General Attributes")]
    public int attack_counter;
    public float cooldown;

    [Space]

    [Header("Spear Attributes")]
    public int range;
    //Basic attack 1
    //Basic attack 2
    //Spear Specific Skill

    // Start is called before the first frame update
    void Start()
    {
        attack_counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Basic_Attack()
    {

    }
}
