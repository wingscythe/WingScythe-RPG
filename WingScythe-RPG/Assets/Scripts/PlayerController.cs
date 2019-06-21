using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Prefabs")]
    public Rigidbody2D rb;
    public Animator anim;
    public Joystick joystick;

    [Space]

    [Header("Weapon Attributes")]
    public float MOVESPEED = 0.05f;
    public float COOLDOWN = 3f;

    [Space]

    [Header("Input Settings")]
    public Vector2 move_direction;

    [Space]

    [Header("Dash Attributes")]
    public float dash_speed = 0.3f;
    private float dash_time = 0f;
    public float start_time = 0.15f;
    public float cooldown = 0f;
    public bool dashing;
    public float frontBack;
    public float leftRight;

    // Start is called before the first frame update
    void Start()
    {
        //State Calibration
        rb = GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        dash_time = start_time;
        cooldown = 0;
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (!dashing)
        {
            movement();
        }

        if (dashing || (Input.GetKeyDown(KeyCode.C) && cooldown <= 0))
        {
            dashing = true;
            PlayerDash();
            cooldown = COOLDOWN;
        }

        if (cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    void movement()
    {

        leftRight = joystick.Horizontal;
        frontBack = joystick.Vertical;

        if (leftRight < -0.2f && this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            this.gameObject.transform.Translate(new Vector3(-MOVESPEED, 0f, 0f));
        }
        else if (leftRight > 0.2f && this.gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            this.gameObject.transform.Translate(new Vector3(MOVESPEED, 0f, 0f));
        }
        else if (frontBack < -0.2f)
        {
            this.gameObject.transform.Translate(new Vector3(0f, -MOVESPEED, 0f));
        }
        else if (frontBack > 0.2f)
        {
            this.gameObject.transform.Translate(new Vector3(0f, MOVESPEED, 0f));
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

    void PlayerDash()
    {   
        if (dash_time<=0)
        {
            dash_time = start_time;
            dashing = false;
        }

        if (dash_time > 0)
        {
            dash_time -= Time.deltaTime;
            this.gameObject.transform.Translate(new Vector3(leftRight, frontBack, 0f) * dash_speed);
        }
    }
}
