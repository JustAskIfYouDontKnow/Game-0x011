
public abstract class State
{
    protected AIBrain ai;
    protected StateMachine stateMachine;
    
    public State(AIBrain ai, StateMachine stateMachine)
    {
        this.ai = ai;
        this.stateMachine = stateMachine;
    }
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();
}