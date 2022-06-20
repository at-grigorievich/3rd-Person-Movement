using System;

namespace ATGStateMachine
{
    public interface IStrategyStateBehaviour
    {
        void Init(object obj);
        void Enter();
        void Execute();
        void Exit();
    }
}