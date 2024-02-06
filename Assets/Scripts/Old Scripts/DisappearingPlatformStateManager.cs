using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformStateManager : MonoBehaviour
{
    public DisappearingPlatformBaseState currentState;
    public DisappearingPlatformDeactivatedState DeactivatedState = new DisappearingPlatformDeactivatedState();
    public DisappearingPlatformActivatedState ActivatedState = new DisappearingPlatformActivatedState();

    private void Start()
    {
        currentState = ActivatedState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(this, collision);
    }
    public void SwitchState(DisappearingPlatformBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
