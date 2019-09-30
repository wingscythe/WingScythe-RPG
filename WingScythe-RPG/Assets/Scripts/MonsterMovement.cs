using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This controls the movement the basic monster does.
 * 
 * Author: Andy Zheng
 * **/
public class MonsterMovement : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public Rigidbody2D rb;
    public Collider2D self_col;
    public RaycastHit2D up, down, left, right;

    /**
     * Initializes all the fields except for player.
     * Starts a Coroutine which controls what the slime decides to do.
     * **/
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        self_col = this.gameObject.GetComponent<CircleCollider2D>();
        up = Physics2D.Raycast(transform.position, new Vector2(0, 1), 1f);
        down = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1f);
        left = Physics2D.Raycast(this.transform.position, new Vector2(-1, 0), 1f);
        right = Physics2D.Raycast(this.transform.position, new Vector2(1, 0), 1f);
        StartCoroutine(movementDelay(0.5f));
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetBool("Attack", true);
        }
    }
    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            anim.SetBool("Attack", true);
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Attack", false);
        }
    }
    /**
     * This is the Coroutine, which controls the movement. If the player is within a 5 radius 
     * 
     * @param: 
     * float time is the time it takes 
     * **/
    IEnumerator movementDelay(float time)
    {
        while (this.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(time);
            idle_Movement();
        }
    }
    
    /**
     * 80% chance of moving randomly and 20% chance of staying in idle state. 
     * 
     * **/
    void idle_Movement()
    { 
        float randPercent = Random.Range(0f, 100f);
        if (randPercent < 80)
        {
            anim.SetBool("Walk", true);
        }
        else if (randPercent >= 80 && randPercent < 100)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
        }
        
    }
}
