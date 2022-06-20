using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATGStateMachine
{
    /// <summary>
    /// Base class of any object state
    /// This type can manipulate data of type T
    /// And also change the state based on the conditions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseStatement<T>
    {
        protected readonly T MainObject; // Manipulate object
        protected readonly IStateSwitcher StateSwitcher; // Switch state

        protected BaseStatement(T mainObject, IStateSwitcher stateSwitcher)
        {
            MainObject = mainObject;
            StateSwitcher = stateSwitcher;
        }

        public abstract void Enter(); // Enter the state callback
        public virtual void Exit() { } // Exit the state callback
        public virtual void Execute() { } // Stay the state callback
    }
}
