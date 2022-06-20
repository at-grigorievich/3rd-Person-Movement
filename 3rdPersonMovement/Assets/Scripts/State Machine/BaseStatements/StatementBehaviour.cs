using System.Collections.Generic;
using UnityEngine;
using System;

namespace ATGStateMachine
{
    /// <summary>
    /// The base class of any object that can have several states
    /// _currentState contains the current state
    /// _allStates contains all possible states for a given object
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    public class StatementBehaviour<T> : MonoBehaviour, IStateSwitcher
    {
        private BaseStatement<T> _currentState;
        private BaseStatement<T> _waitingState;
        
        protected readonly List<BaseStatement<T>> AllStates = new List<BaseStatement<T>>();
        
        // Call after init all states
        protected void InitStartState() => _currentState = AllStates[0];
        
        // Call to Enter to current state
        public virtual void OnState(bool isExit = false) =>_currentState?.Enter();
        
        // Call to Execute current state
        public virtual void OnExecute() => _currentState?.Execute();
        
        // Call to continue work of state machine
        public virtual void OnContinueState()
        {
            if (_waitingState != null && _currentState == null)
            {
                _currentState = _waitingState;
                _waitingState = null;
            }
            else Debug.LogError("Waiting state in null !");
        }
        
        // Call to stop work of state machine
        public virtual void OnPauseState()
        {
            if(_currentState != null)
            {
                _waitingState = _currentState;
                _currentState = null;
            }
        }
       
        // Call to stop state machine working
        public virtual void OnStopState()
        {
            if(_currentState != null)
            {
                _currentState.Exit();
                _currentState = null;

                AllStates.Clear();
            }
        }

        // switch object state
        public virtual void StateSwitcher<TK>()
        {
            var state = AllStates.Find(state => state is TK);
            
            if (state != _currentState && state != null)
            {
                if (_currentState != null)
                {
                    _currentState.Exit();
                }
                _currentState = state;
                state.Enter();
            }
        }
    }
}