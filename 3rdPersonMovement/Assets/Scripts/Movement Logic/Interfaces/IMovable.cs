using BotLogic;
using BotMovement.MoveLogic;

namespace Movement.Interfaces
{
    public interface IMovable
    {
        MoveService MoveService { get; }
        BotAnimatorService AnimatorService { get; }
    }
}