using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GemAnimationScript : StateMachineBehaviour
{
    private Vector2 upPosition;
    private Vector2 downPosition;
    private bool isMovingUp;
    private float moveSpeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        upPosition = new Vector2(animator.transform.position.x, animator.transform.position.y + 0.5f);
        downPosition = new Vector2(animator.transform.position.x, animator.transform.position.y);
        isMovingUp = true;
        moveSpeed = 0.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float step = moveSpeed * Time.deltaTime;
        if (isMovingUp)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, upPosition, step);

            // Check if the object has reached the target y position
            if (animator.transform.position.y >= upPosition.y)
            {
                isMovingUp = false;
            }
        }
        else
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, downPosition, step);

            // Check if the object has reached the starting y position
            if (animator.transform.position.y <= downPosition.y)
            {
                isMovingUp = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
