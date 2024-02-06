using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformDeactivatedState : DisappearingPlatformBaseState
{
    private float timer;
    public override void EnterState(DisappearingPlatformStateManager disappearingPlatform)
    {
        timer = 0f;
        disappearingPlatform.GetComponentInParent<SpriteRenderer>().enabled = false;
        Component[] colliders = disappearingPlatform.GetComponentsInParent<BoxCollider2D>();
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
    public override void UpdateState(DisappearingPlatformStateManager disappearingPlatform)
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            disappearingPlatform.SwitchState(disappearingPlatform.ActivatedState);
        }
    }
    public override void OnCollisionEnter2D(DisappearingPlatformStateManager disappearingPlatform, Collision2D collision)
    {

    }
}
