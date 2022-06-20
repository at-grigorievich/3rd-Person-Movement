using System;
using UnityEngine;

namespace AnimatorControl
{
    public enum StateType
    {
        Bool,
        Trigger
    }
    
    [Serializable]
    public class AnimatorState
    {
        [SerializeField] private AnimatorAction actionType;
        [SerializeField] private StateType stateType;
        [SerializeField] private string stateName;

        public AnimatorAction ActionType => actionType;
        public StateType AnimatorStateType => stateType;

        public Action<Animator> ChangeState(bool value)
        {
            switch (stateType)
            {
                case StateType.Bool:
                    return (animator) => animator.SetBool(stateName, value);
                case StateType.Trigger:
                    if (value)
                    {
                        return (animator => animator.SetTrigger(stateName));
                    }
                    break;
            }
            return null;
        }
    }
}