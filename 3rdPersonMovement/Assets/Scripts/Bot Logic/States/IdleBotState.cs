using System;
using ATGStateMachine;

namespace BotLogic.States
{
    public class IdleBotState: BaseStatement<IAgent>
    {
        private readonly Func<bool> _tryToMove;
        
        public IdleBotState(IAgent mainObject, IStateSwitcher stateSwitcher, Func<bool> tryToMove) 
            : base(mainObject, stateSwitcher)
        {
            _tryToMove = tryToMove;
        }

        public override void Enter()
        {
            MainObject.AgentAnimator.AnimateIdle();
        }

        public override void Execute()
        {
            if (_tryToMove())
            {
                StateSwitcher.StateSwitcher<MoveBotState>();
            }
        }
    }
}