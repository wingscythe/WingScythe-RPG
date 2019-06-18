using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_JoyStick_Controller : MonoBehaviour
{
    public Animator anim;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();

    }

    void movement()
    {

        float leftRight = joystick.Horizontal;
        float frontBack = joystick.Vertical;
        
        if (leftRight < -0.5f && this.gameObject.GetComponent<SpriteRenderer>().flipX == true) {
            this.gameObject.transform.Translate(new Vector3(-0.05f, 0f, 0f));
        }
        else if (leftRight > 0.5f && this.gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            this.gameObject.transform.Translate(new Vector3(0.05f, 0f, 0f));
        }
        else if (frontBack < -0.5f)
        {
            this.gameObject.transform.Translate(new Vector3(0f, -0.05f, 0f));
        }
        else if (frontBack > 0.5f)
        {
            this.gameObject.transform.Translate(new Vector3(0f, 0.05f, 0f));
        }
        
        anim.SetFloat("Vertical_Walk", Mathf.Abs(leftRight));
        anim.SetFloat("Horizontal_Walk", frontBack);

        if (leftRight > 0.2f)
        {
            anim.SetBool("Horizontal_Move", true);
            anim.SetBool("Face_Back", false);
            if (this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (leftRight < -0.2f)
        {
            anim.SetBool("Horizontal_Move", true);
            anim.SetBool("Face_Back", false);
            if (this.gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (frontBack > 0.2f)
        {
            anim.SetBool("Face_Back", true);
            anim.SetBool("Horizontal_Move", false);
        }
        else if (frontBack < -0.2f)
        {
            anim.SetBool("Face_Back", false);
            anim.SetBool("Horizontal_Move", false);
        }

    }
}
