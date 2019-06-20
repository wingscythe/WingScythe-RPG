using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP : MonoBehaviour
{
    public Text hptext;
    public int mp = 100;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            mp--;
            hptext.text = getMp().ToString();
        }
    }

    int getMp()
    {
        return mp;
    }




}
