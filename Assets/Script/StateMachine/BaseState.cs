using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected StateMachine ctx;

    public void Init(StateMachine machine)
    {
        ctx = machine;
    }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
}
