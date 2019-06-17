using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickCharacterMovement : MonoBehaviour
{
    
    public Animator anim;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.SetBool("num1", true);
            anim.SetBool("num2", false);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.SetBool("num1", false);
            anim.SetBool("num2", true);
        }
        else
        {
            anim.SetBool("num1", false);
            anim.SetBool("num2", false);
        }
    }
    /*
        float direction = joystick.Horizontal;
        if (direction > 0)
        {
            anim.SetFloat("Direction", 1.0f);
        }
        else if (direction < 0)
        {
            anim.SetFloat("Direction", -1.0f);
        }
        else
        {
            anim.SetFloat("Direction", 0.0f);
        }

        float movement = joystick.Vertical;

        if (movement > 0)
        {
            anim.SetFloat("Speed", 0.5f);
        }
        else if (movement < 0)
        {
            anim.SetFloat("Speed", -0.5f);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }
    */
}
