using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;
    public int[] moveplace = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        idle_Movement();
    }

    void idle_Movement()
    { 
        RaycastHit2D up = Physics2D.Raycast(transform.position, new Vector2(0, 1));
        RaycastHit2D down = Physics2D.Raycast(transform.position, new Vector2(0, -1));
        RaycastHit2D left = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
        RaycastHit2D right = Physics2D.Raycast(transform.position, new Vector2(1, 0));

        if (up.collider != null)
        {
            moveplace[0] = 1;
        }
        else
        {
            moveplace[0] = 0;
        }

        if (down.collider != null)
        {
            moveplace[1] = 1;
        }
        else
        {
            moveplace[1] = 0;
        }

        if (left.collider != null)
        {
            moveplace[2] = 1;
        }
        else
        {
            moveplace[2] = 0;
        }

        if (right.collider != null)
        {
            moveplace[3] = 1;
        }
        else
        {
            moveplace[3] = 0;
        }

        int counter = 0;

        for (int i = 0; i < moveplace.Length; i++)
        {
            if (moveplace[i] == 0)
            {
                counter++;
            }
        }
        double percent = 100.0 / counter;

        float addon = Random.Range(0f, 100f);

        
    }

}
