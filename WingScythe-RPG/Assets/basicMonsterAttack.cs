using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMonsterAttack : StateMachineBehaviour
{
    public GameObject player;
    public GameObject self;
    public Rigidbody2D rb2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        self = GameObject.FindGameObjectWithTag("Slime");
        rb2 = self.gameObject.GetComponent<Rigidbody2D>();
        // if (Mathf.Abs(Vector2.Distance(player.transform.position, self.transform.position)) > 1.4) {
        //     animator.SetBool("Attack", false);
        //     animator.SetBool("Walk", true);
        // }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if (Mathf.Abs(Vector2.Distance(player.transform.position, self.transform.position)) < 1.4)
        // {
        //     animator.SetBool("Attack", true);
        // }
        // else
        // {
        //     animator.SetBool("Attack", false);
        // }
        animator.SetBool("Attack", false);
        // rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
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
