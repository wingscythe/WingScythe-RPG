using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 move_direction;
    public float move_speed = 0;

    private float speed_scalar = 5;

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

        //Attack based on weapon and skill combinations
    }

    void PlayerMoveProcessing()
    {
        move_direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move_speed = Mathf.Clamp(move_direction.magnitude, 0.0f, 1.0f);
        move_direction.Normalize();
    }

    void PlayerMove()
    {
        rb.velocity = move_direction * move_speed * speed_scalar; 
    }
}
