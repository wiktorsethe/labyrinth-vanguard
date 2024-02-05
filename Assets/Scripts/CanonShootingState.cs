using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShootingState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CanonShooting>().StartCoroutine(animator.GetComponent<CanonShooting>().Shoot());
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetComponent<CanonShooting>().isReadyForShoot)
        {
            animator.SetTrigger("Rotation");
        }
    }
}
