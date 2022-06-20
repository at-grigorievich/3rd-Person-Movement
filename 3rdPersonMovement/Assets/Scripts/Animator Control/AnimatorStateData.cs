using System;
using UnityEngine;

namespace AnimatorControl
{
    [CreateAssetMenu(fileName = "Animator States Data", menuName = "Animator Controll / Neew Animator States Data", order = 0)]
    public class AnimatorStateData : ScriptableObject
    {
        [SerializeField] private AnimatorState[] states;

        public void SetState(Animator animator, AnimatorAction action, bool actionValue, bool isOffOther = false)
        {
            foreach (var state in states)
            {
                if (state.ActionType == action)
                {
                    SetOneState(animator,state,actionValue);
                }
                else if (isOffOther)
                {
                    SetOneState(animator,state,false);
                }
            }
        }


        private void SetOneState(Animator animator, AnimatorState state, bool value)
        {
            state.ChangeState(value)?.Invoke(animator);
        }
    }
}
