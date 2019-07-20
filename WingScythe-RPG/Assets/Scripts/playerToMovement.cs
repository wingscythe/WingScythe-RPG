using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerToMovement : StateMachineBehaviour
{

    public GameObject target;
    public GameObject player;
    RaycastHit2D up;
    RaycastHit2D down;
    RaycastHit2D left;
    RaycastHit2D right;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Slime");
        player = GameObject.FindGameObjectWithTag("Player");
        up = Physics2D.Raycast(target.transform.position, new Vector2(0, 1), 1f);
        down = Physics2D.Raycast(target.transform.position, new Vector2(0, -1), 1f);
        left = Physics2D.Raycast(target.transform.position, new Vector2(-1, 0), 1f);
        right = Physics2D.Raycast(target.transform.position, new Vector2(1, 0), 1f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (up.collider != null)
        {
            if (up.collider.gameObject.CompareTag("Player"))
            {
                animator.SetTrigger("Attack");
                animator.SetBool("Walk2", false);
            }
            else
            {
                target.transform.Translate(new Vector2(0, 0.05f));
            }
        }
        else if (right.collider != null)
        {
            if (right.collider.gameObject.CompareTag("Player"))
            {
                animator.SetTrigger("Attack");
                animator.SetBool("Walk2", false);
            }
            else
            {
                target.transform.Translate(new Vector2(0.05f, 0));
            }
        }
        else if (down.collider != null)
        {
            if (down.collider.gameObject.CompareTag("Player"))
            {
                animator.SetTrigger("Attack");
                animator.SetBool("Walk2", false);
            }
            else
            {
                target.transform.Translate(new Vector2(0, -0.05f));
            }
        }
        else if (left.collider != null)
        {
            if (left.collider.gameObject.CompareTag("Player"))
            {
                animator.SetTrigger("Attack");
                animator.SetBool("Walk2", false);
            }
            else
            {
                target.transform.Translate(new Vector2(-0.05f, 0));
            }
        }
        else {
            target.transform.position = Vector2.MoveTowards(target.transform.position, player.transform.position, 0.05f);
        }

        if (player.transform.position.x < target.transform.position.x)
        {
            target.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (player.transform.position.x > target.transform.position.x)
        {
            target.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Walk2", false);
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
