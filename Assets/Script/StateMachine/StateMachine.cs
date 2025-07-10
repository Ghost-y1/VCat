using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private BaseState[] allStates;

    private BaseState currentState;

    public StatsManager Stats { get; private set; }

    void Awake()
    {
        Stats = GetComponent<StatsManager>();

        foreach (var state in allStates)
        {
            state.Init(this);
        }
        if (allStates.Length > 0)
        {
            ChangeState(allStates[0]);
        }
    }

    void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(BaseState newState)
    {
        if (newState == currentState) return;

        currentState?.ExitState();
        currentState = newState;
        currentState?.EnterState();
    }
}