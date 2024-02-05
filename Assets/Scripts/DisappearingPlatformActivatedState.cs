using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformActivatedState : DisappearingPlatformBaseState
{
    private float timer;
    private bool isCollision;
    public override void EnterState(DisappearingPlatformStateManager disappearingPlatform)
    {
        timer = 0f;
        isCollision = false;
        disappearingPlatform.GetComponentInParent<SpriteRenderer>().enabled = true;
        Component[] colliders = disappearingPlatform.GetComponentsInParent<BoxCollider2D>();
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = true;
        }
    }
    public override void UpdateState(DisappearingPlatformStateManager disappearingPlatform)
    {
        if (isCollision)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                disappearingPlatform.SwitchState(disappearingPlatform.DeactivatedState);
            }
        }
           
    }
    public override void OnCollisionEnter2D(DisappearingPlatformStateManager disappearingPlatform, Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            isCollision = true;
        }
    }
}
