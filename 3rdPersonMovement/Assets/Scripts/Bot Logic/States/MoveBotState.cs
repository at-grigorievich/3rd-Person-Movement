using ATGStateMachine;

namespace BotLogic.States
{
    public class MoveBotState: BaseStrategyStatement<IAgent>
    {
        public MoveBotState(IAgent mainObject, IStateSwitcher stateSwitcher, 
            IStrategyStateBehaviour strategyState)
            : base(mainObject, stateSwitcher, strategyState)
        {
        }
    }
}