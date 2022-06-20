namespace ATGStateMachine
{
    public class BaseStrategyStatement<T>: BaseStatement<T>
    {
        private readonly IStrategyStateBehaviour _strategyState;
        
        public BaseStrategyStatement(T mainObject, IStateSwitcher stateSwitcher,IStrategyStateBehaviour strategyState) 
            : base(mainObject, stateSwitcher)
        {
            _strategyState = strategyState;
            _strategyState.Init(mainObject);
        }

        public override void Enter() => _strategyState.Enter();
        public override void Execute() => _strategyState.Execute();
        public override void Exit() => _strategyState.Exit();
    }
}