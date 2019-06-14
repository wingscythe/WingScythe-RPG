using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Prefabs")]
    public Rigidbody2D rb;

    [Space]

    [Header("Weapon Attributes")]
    public float MOVESPEED = 5.75f;

    [Space]

    [Header("Input Settings")]
    public Vector2 move_direction;
    public float move_speed;

    // Start is called before the first frame update
    void Start()
    {
        //State Calibration
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        PlayerMoveProcessing();
        PlayerMove();
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
}
