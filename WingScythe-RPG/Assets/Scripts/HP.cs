using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Text hptext;
    public InputField hP;
    public int hp = 100;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            hp--;
            hptext.text = getHp().ToString();
        }
        if (hp < 50)
        {
           // change color to yellow
        }
    }

    int getHp()
    {
        return hp;
    }




}
