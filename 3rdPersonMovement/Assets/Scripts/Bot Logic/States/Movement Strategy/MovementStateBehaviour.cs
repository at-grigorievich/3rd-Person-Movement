using System;
using ATGStateMachine;

namespace BotLogic.States
{
    public abstract class MovementStateBehaviour: IStrategyStateBehaviour
    {
        protected IAgent _mainObject;
        
        public void Init(object obj)
        {
            if (obj is IAgent agent)
            {
                _mainObject = agent;
            }
            else
            {
                throw new ArgumentException("Cant init movement state, obj isnt IAgent!");
            }
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}