using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Text hptext;
    public Image hP;
    public int hp = 100;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            hp--;
            hptext.text = getHp().ToString();
        }
        if (getHp() <= 50)
        {
            hptext.color = Color.black;
            hP.color = Color.yellow;
        }

        if (getHp() <= 25)
        {
            hP.color = Color.red;
        }

        if (getHp() == 0) restart();
    }

    int getHp()
    {
        return hp;
    }

    void restart()
    {
        if (hp == 0)
        {
            //dies here
        }
    }




}
