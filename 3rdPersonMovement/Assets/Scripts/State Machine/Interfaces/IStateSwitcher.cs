using System;

namespace ATGStateMachine 
{
    /// <summary>
    /// State switching interface
    /// </summary>
    public interface IStateSwitcher
    {
        void StateSwitcher<T>();
    }
}
