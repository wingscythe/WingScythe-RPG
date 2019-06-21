using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(movementDelay(0.3f));
    }
    
    IEnumerator movementDelay(float time)
    {
        while (this.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(time);
            if (Vector2.Distance(player.transform.position, this.gameObject.transform.position) < 10)
            {
                Vector2 travel = Vector2.MoveTowards(this.gameObject.transform.position, player.transform.position, 0.5f);
                this.gameObject.transform.position = travel;

                anim.SetBool("Walk2", true);
                anim.SetBool("Walk", false);
                if (player.transform.position.x < this.gameObject.transform.position.x)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (player.transform.position.x > this.gameObject.transform.position.x)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                idle_Movement();
            }
        }
    }

    void idle_Movement()
    { 
        float randPercent = Random.Range(0f, 100f);
        if (randPercent < 80)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Walk2", false);
        }
        else if (randPercent >= 80 && randPercent < 100)
        {
            anim.SetBool("Walk", false);
            anim.ResetTrigger("Attack");
            anim.SetBool("Walk2", false);
        }
        
    }
}
