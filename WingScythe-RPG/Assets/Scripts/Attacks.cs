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
        attack.onClick.AddListener(Basic);
        spAtk1.onClick.AddListener(SpAtk1);
        spAtk2.onClick.AddListener(SpAtk2);
        spAtk3.onClick.AddListener(SpAtk3);
        getWeapon();
    }

    void getWeapon()
    {
        wp = hero.transform.GetChild(0).gameObject.GetComponent<Weapon>();
    }

    public void Basic()
    {
        wp.Basic_Attack();
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
        wp.Special_Attack(index);
    }
}
