using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Prefabs")]
    public Rigidbody2D rb;
    public CircleCollider2D hitbox;

    [Space]

    [Header("Weapon Attributes")]
    public float MOVESPEED = 5.75f;
    public float COOLDOWN = 5f;

    [Space]

    [Header("Input Settings")]
    public Vector2 move_direction;
    public float move_speed;

    [Space]

    [Header("Dash Attributes")]
    public float dash_speed;
    private float dash_time;
    public float start_time;
    public float cooldown;
    public bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        //State Calibration
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
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
            PlayerMoveProcessing();
        }

        if ((Input.GetKeyDown(KeyCode.C) && cooldown <= 0) || dashing)
        {
            hitbox.enabled = false;
            dashing = true;
            PlayerDash();
            cooldown = COOLDOWN;
        }

        if (cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }

        if (!dashing)
        {
            PlayerMove();
        }
    }

    void PlayerMoveProcessing()
    {
        move_direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move_speed = Mathf.Clamp(move_direction.magnitude, 0.0f, 1.0f);
        move_direction.Normalize();
    }

    void PlayerMove()
    {
        rb.velocity = move_direction * move_speed * MOVESPEED; 
    }
    
    void PlayerDash()
    {
        if (dash_time<=0)
        {
            dash_time = start_time;
            dashing = false;
            hitbox.enabled = true;
        }

        if (dash_time > 0)
        {
            dash_time -= Time.deltaTime;
            rb.velocity = move_direction * dash_speed;
        }
    }
}
