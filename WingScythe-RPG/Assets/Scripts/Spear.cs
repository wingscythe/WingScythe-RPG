using UnityEngine;
using System.Collections;

public class Spear : Item
{
    [Header("Weapon Attributes")]
    public int attack_counter;
    public float cooldown;
    public float RESET = 2f;

    [Space]

    [Header("Spear Attributes")]
    public int range;
    private Animator animator;
    
    //Stats

    // Start is called before the first frame update
    void Start()
    {
        attack_counter = 0;
        item_name = "Spear";
        type = "weapon";
        item = Instantiate(Resources.Load("Spear/Spear.prefab", typeof(GameObject)), Vector2.zero, Quaternion.identity) as GameObject;
        animator = item.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if(RESET > 0)
        {
            RESET--;
        }else if(RESET <= 0)
        {
            attack_counter = 0;
        }
    }

    public override void Basic_Attack()
    {
        if(cooldown > 0)
        {
            //TODO: Grey out and fill button
            return;
        }

        animator.SetTrigger("Basic_Attack");
        attack_counter++;
        cooldown += 1f;
        RESET = 2f;
    }

    public override void Special_Attack(int index)
    {
        animator.SetTrigger("Special_Attack_" + index);
        attack_counter++;
        cooldown += 1f;
        RESET = 2f;
    }

    public override void Consume()
    {
        throw new System.NotImplementedException();
    }

    public override void DoubleClick()
    {
        //TODO: Equip Weap
    }
}
