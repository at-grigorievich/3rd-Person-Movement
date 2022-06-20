using UnityEngine;

namespace AnimatorControl
{
    public class AnimatorBehaviour : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected AnimatorStateData statesData;

        protected virtual void SetOnlyOneState(AnimatorAction action, bool value) =>
            statesData.SetState(animator, action, value);

        protected virtual void SetOneState(AnimatorAction action, bool value) =>
            statesData.SetState(animator, action, value, true);
    }
}