using ATGAnimatorHC;

namespace BotLogic
{
    public class BotAnimatorService: AnimatorBehaviour
    {
        public void AnimateIdle() => SetOneStateAndOffOther(AnimatorAction.Idle, true);
        public void AnimateMove() => SetOneStateAndOffOther(AnimatorAction.Run, true);
    }
}