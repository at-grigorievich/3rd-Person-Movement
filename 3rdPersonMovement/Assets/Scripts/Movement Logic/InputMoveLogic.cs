using ATGStateMachine;
using BotLogic;
using BotMovement.MoveLogic;
using InputService;
using Movement.Interfaces;
using MovementLogic.States;
using Zenject;

namespace MovementLogic
{
    public class InputMoveLogic : IMovable, ITickable
    {
        private readonly StatementsContainer<IMovable> _states;

        public MoveService MoveService { get; private set; }
        public BotAnimatorService AnimatorService { get; private set; }


        public InputMoveLogic(IInputable inputable, float smooth,
            BotAnimatorService animator, MoveService moveService)
        {
            MoveService = moveService;
            AnimatorService = animator;

            _states = new StatementsContainer<IMovable>();

            _states.AddState(new InputIdleState(this, _states, inputable));
            _states.AddState(new InputMoveState(this, _states, inputable, smooth));

            _states.OnInitState<InputIdleState>();
        }

        public void Tick()
        {
            _states.OnExecuteState();
        }
    }
}