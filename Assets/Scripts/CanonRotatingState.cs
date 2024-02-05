using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotatingState : StateMachineBehaviour
{
    private GameObject player;
    private float targetDistance = 7f;
    private float timer;
    private float rotationModifier = 88;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(animator.transform.position, player.transform.position);

        if(distance < targetDistance)
        {
            timer += Time.deltaTime;

            if (timer > 4)
            {
                animator.GetComponent<CanonShooting>().isReadyForShoot = true;
                timer = 0f;
                animator.SetTrigger("Shoot");
            }

            Vector3 vectorToTarget = player.transform.position - animator.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            animator.transform.Find("CanonMain").transform.rotation = Quaternion.Slerp(animator.transform.Find("CanonMain").transform.rotation, q, Time.deltaTime * 5f);
        }
    }
}
