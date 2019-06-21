using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(movementDelay(1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        //idle_Movement();
    }

    IEnumerator movementDelay(float time)
    {
        while (this.gameObject.activeSelf)
        {
            idle_Movement();
            yield return new WaitForSeconds(time);
        }
    }

    void idle_Movement()
    { 
        RaycastHit2D up = Physics2D.Raycast(transform.position, new Vector2(0, 1));
        RaycastHit2D down = Physics2D.Raycast(transform.position, new Vector2(0, -1));
        RaycastHit2D left = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
        RaycastHit2D right = Physics2D.Raycast(transform.position, new Vector2(1, 0));

        float randPercent = Random.Range(0f, 100f);
        if (up.collider != null && randPercent < 20)
        {
            this.gameObject.transform.Translate(new Vector2(0, 0.5f));
            anim.SetBool("Walk", true);
        }
        else if (down.collider != null && 20 <= randPercent && randPercent < 40)
        {
            this.gameObject.transform.Translate(new Vector2(0, -0.5f));
            anim.SetBool("Walk", true);
        }
        else if (left.collider != null && 40 <= randPercent && randPercent < 60)
        {
            this.gameObject.transform.Translate(new Vector2(-0.5f, 0));
            anim.SetBool("Walk", true);
            if (this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (right.collider != null && 60 <= randPercent && randPercent < 80)
        {
            this.gameObject.transform.Translate(new Vector2(0.5f, 0));
            anim.SetBool("Walk", true);
            if (this.gameObject.GetComponent<SpriteRenderer>().flipX == false)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (randPercent >= 90 && randPercent < 100)
        {
            anim.SetBool("Walk", false);
            anim.ResetTrigger("Attack");
        }
        else {
            randPercent = Random.Range(0f, 100f);
        }
        
    }
}
