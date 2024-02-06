using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisappearingPlatformBaseState
{
    public abstract void EnterState(DisappearingPlatformStateManager disappearingPlatform);
    public abstract void UpdateState(DisappearingPlatformStateManager disappearingPlatform);
    public abstract void OnCollisionEnter2D(DisappearingPlatformStateManager disappearingPlatform, Collision2D collision);
}
