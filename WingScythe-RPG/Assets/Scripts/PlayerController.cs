using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls player movement
 * 
 * Authors: Ryan Xu, Jeffrey Weng, Andy Zheng
 * */
public class PlayerController : MonoBehaviour
{
    [Header("Prefabs")]
    public Rigidbody2D rb;
    public Animator anim;
    public Joystick joystick;

    [Space]

    [Header("Weapon Attributes")]
    public float MOVESPEED = 3f;
    public float COOLDOWN = 3f;
    public float MIN_SPEED = 0.3f;

    [Space]

    [Header("Input Settings")]
    public float frontBack;
    public float leftRight;

    [Space]

    [Header("Dash Attributes")]
    public float dash_speed = 0.3f;
    private float dash_time = 0f;
    public float start_time = 0.15f;
    public float cooldown = 0f;
    public bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        //Get Saved State

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
        // move character 
        leftRight = joystick.Horizontal;
        frontBack = joystick.Vertical;

        // add min bounds so char doesnt just slide slowly 
        if (Mathf.Abs(leftRight) > MIN_SPEED || Mathf.Abs(frontBack) > MIN_SPEED)
        {
            Vector2 v = new Vector2(leftRight * MOVESPEED, frontBack * MOVESPEED);
            rb.velocity = v;
        }

        // set character sprite direction 
        if (Mathf.Abs(leftRight) > MIN_SPEED || Mathf.Abs(frontBack) > MIN_SPEED)
        {

            if (Mathf.Abs(leftRight) < Mathf.Abs(frontBack))
            {
                // if moving more up or down
                anim.SetBool("Horizontal_Move", false);
                anim.SetFloat("Vertical_Walk", Mathf.Abs(frontBack));

                if (frontBack > 0)
                {
                    // moving up
                    anim.SetBool("Face_Back", true);
                }
                else
                {
                    // moving down 
                    anim.SetBool("Face_Back", false);
                }

            }
            else
            {
                // if moving more right or left
                anim.SetBool("Horizontal_Move", true);
                anim.SetFloat("Horizontal_Walk", Math.Abs(leftRight));
                anim.SetBool("Face_Back", false);
                if (leftRight > 0)
                {
                    // moving right
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    // moving left 
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        else
        {
            // character not moving
            rb.velocity = Vector2.zero;
            anim.SetFloat("Vertical_Walk", 0);
            anim.SetFloat("Horizontal_Walk", 0);
        }

        /*
        leftRight = joystick.Horizontal;
        frontBack = joystick.Vertical;

        if (leftRight < -0.2f && this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            rb.velocity = new Vector2(-MOVESPEED, 0f);
        }
        else if (leftRight > 0.2f && this.gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            rb.velocity = new Vector2(MOVESPEED, 0f);
        }
        else if (frontBack < -0.2f)
        {
            rb.velocity = new Vector2(0f, -MOVESPEED);
        }
        else if (frontBack > 0.2f)
        {
            rb.velocity = new Vector2(0f, MOVESPEED);
        }
        else
        {
            rb.velocity = Vector2.zero;
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
        */
    }

    /*
     * Allows player to dash in the last inputted direction
     * 
     * Author: Ryan Xu
     * */
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
            rb.velocity = new Vector2(leftRight, frontBack) * dash_speed;
        }
    }
}
