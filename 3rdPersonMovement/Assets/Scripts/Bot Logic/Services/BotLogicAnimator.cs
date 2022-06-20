using AnimatorControl;

namespace BotLogic.Services
{
    public class BotLogicAnimator: AnimatorBehaviour
    {
        public void AnimateIdle() => SetOneState(AnimatorAction.Idle, true);
        public void AnimateMove() => SetOneState(AnimatorAction.Run, true);
    }
}