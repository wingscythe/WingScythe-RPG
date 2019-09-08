using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMonsterMovement : StateMachineBehaviour
{
    public GameObject player;
    public GameObject self;
    public Rigidbody2D rb2;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private int choice = 0;
    RaycastHit2D up;
    RaycastHit2D down;
    RaycastHit2D left;
    RaycastHit2D right;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        self = GameObject.FindGameObjectWithTag("Slime");
        rb2 = self.GetComponent<Rigidbody2D>();
        up = Physics2D.Raycast(self.transform.position, new Vector2(0, 1));
        down = Physics2D.Raycast(self.transform.position, new Vector2(0, -1));
        left = Physics2D.Raycast(self.transform.position, new Vector2(-1, 0));
        right = Physics2D.Raycast(self.transform.position, new Vector2(1, 0));

        float randPercent = Random.Range(0f, 100f);
        Debug.Log(randPercent);
        if (up.collider != null && randPercent < 50)
        {
            choice = 1;
            Debug.Log("up");
        }
        else if (down.collider != null && 25 <= randPercent && randPercent < 50)
        {
            choice = 2;
            Debug.Log("down");
        }
        else if (left.collider != null && 50 <= randPercent && randPercent < 75)
        {
            choice = 3;
            Debug.Log("left");
        }
        else if (right.collider != null && 75 <= randPercent && randPercent < 100)
        {
            choice = 4;
            Debug.Log("right");
        }
        Debug.Log(choice);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(Vector2.Distance(player.transform.position, self.transform.position)) < 1.4)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);
            Debug.Log("Attacking");
        }
        else if (Mathf.Abs(Vector2.Distance(player.transform.position, self.transform.position)) < 6) {
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
            if (player.transform.position.x < self.transform.position.x && self.GetComponent<SpriteRenderer>().flipX == true) {
                self.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (player.transform.position.x > self.transform.position.x && self.GetComponent<SpriteRenderer>().flipX == false)
            {
                self.GetComponent<SpriteRenderer>().flipX = true;
            }
            self.transform.position = Vector2.MoveTowards(self.transform.position, player.transform.position, 0.025f);
        }
        /*else if (self.transform.position.x < minX || self.transform.position.x > maxX || self.transform.position.y < minY || self.transform.position.y > maxY)
        {
            animator.SetBool("Walk", false);
            Debug.Log("Stop");
        }*/
        else if (choice == 1)
        {
            if (self.transform.position.y > maxY)
            {
                animator.SetBool("Walk", false);
            }
            else
            {
                rb2.velocity = new Vector2(0, 0.5f);
            }
        }
        else if (choice == 2)
        {
            if (self.transform.position.y < minY)
            {
                animator.SetBool("Walk", false);
            }
            else
            {
                rb2.velocity = new Vector2(0, -0.5f);
            }
        }
        else if (choice == 3)
        {
            if (self.GetComponent<SpriteRenderer>().flipX == true)
            {
                self.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (self.transform.position.x < minX)
            {
                animator.SetBool("Walk", false);
            }
            else 
            {
                rb2.velocity = new Vector2(-0.5f, 0);
            }
        }
        else if (choice == 4)
        {
            if (self.GetComponent<SpriteRenderer>().flipX == false)
            {
                self.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (self.transform.position.x > maxX)
            {
                animator.SetBool("Walk", false);
            }
            else
            {
                rb2.velocity = new Vector2(0.5f, 0);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2.velocity = Vector2.zero;
        animator.SetBool("Walk", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
