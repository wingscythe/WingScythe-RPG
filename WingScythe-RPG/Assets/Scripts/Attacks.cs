using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacks : MonoBehaviour
{
    public Button attack;
    public Button spAtk1;
    public Button spAtk2;
    public Button spAtk3;
    public Weapon wp;
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        wp = getWeapon();
        attack.onClick.AddListener(Basic);
        spAtk1.onClick.AddListener(SpAtk1);
        spAtk2.onClick.AddListener(SpAtk2);
        spAtk3.onClick.AddListener(SpAtk3);
    }

    Weapon getWeapon()
    {

        return hero.transform.GetChild(0).gameObject.GetComponent<Weapon>();
    }

    public void Basic()
    {
        getWeapon();
        wp.Basic_Attack();
    }

    public void SpAtk1()
    {
        getWeapon();
        PlayerSpecialAttack(1);
    }

    public void SpAtk2()
    {
        getWeapon();
        PlayerSpecialAttack(2);
    }

    public void SpAtk3()
    {
        getWeapon();
        PlayerSpecialAttack(3);
    }

    private void PlayerSpecialAttack(int index)
    {
        getWeapon();
        wp.Special_Attack(index);
    }
}
