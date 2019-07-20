using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : StateMachineBehaviour
{
    public GameObject target;
    private int choice = 0;
    RaycastHit2D up;
    RaycastHit2D down;
    RaycastHit2D left;
    RaycastHit2D right;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Slime");
        up = Physics2D.Raycast(target.transform.position, new Vector2(0, 1));
        down = Physics2D.Raycast(target.transform.position, new Vector2(0, -1));
        left = Physics2D.Raycast(target.transform.position, new Vector2(-1, 0));
        right = Physics2D.Raycast(target.transform.position, new Vector2(1, 0));
        Debug.DrawRay(target.transform.position, new Vector2(0, 1));
        Debug.DrawRay(target.transform.position, new Vector2(0, -1));
        Debug.DrawRay(target.transform.position, new Vector2(-1, 0));
        Debug.DrawRay(target.transform.position, new Vector2(1, 0));

        float randPercent = Random.Range(0f, 100f);
        Debug.Log(randPercent);
        if (up.collider != null && randPercent < 25)
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
            if (target.GetComponent<SpriteRenderer>().flipX == true)
            {
                target.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (right.collider != null && 75 <= randPercent && randPercent < 100)
        {
            choice = 4;
            Debug.Log("right");
            if (target.GetComponent<SpriteRenderer>().flipX == false)
            {
                target.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        Debug.Log(choice);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.DrawRay(target.transform.position, new Vector2(0, 10));
        Debug.DrawRay(target.transform.position, new Vector2(0, -10));
        Debug.DrawRay(target.transform.position, new Vector2(-10, 0));
        Debug.DrawRay(target.transform.position, new Vector2(10, 0));
        if (up.collider != null || down.collider != null || left.collider != null || right.collider != null) {
            animator.SetBool("Walk", false);
            Debug.Log("Hit");
        }
        else if (choice == 1)
        {
            target.transform.Translate(new Vector2(0, 0.05f));
        }
        else if (choice == 2)
        {
            target.transform.Translate(new Vector2(0, -0.05f));
        }
        else if (choice == 3)
        {
            target.transform.Translate(new Vector2(-0.05f, 0));
        }
        else if (choice == 4)
        {
            target.transform.Translate(new Vector2(0.05f, 0));
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
