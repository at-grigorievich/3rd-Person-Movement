using ATGStateMachine;
using Movement.Interfaces;
using InputService;

namespace MovementLogic.States
{
    public class InputIdleState: BaseStatement<IMovable>
    {
        public const float InputSens = 0.05f;
        
        private readonly IInputable _inputService;
        
        public InputIdleState(IMovable mainObject, IStateSwitcher<IMovable> stateSwitcher,
            IInputable inputable) 
            : base(mainObject, stateSwitcher)
        {
            _inputService = inputable;
        }

        public override void Enter()
        {
            MainObject.AnimatorService.AnimateIdle();
        }

        public override void Execute()
        {
            OnCheckInput();
        }
        
        private void OnCheckInput()
        {
            if (_inputService.JoystickValue.magnitude > InputSens)
            {
                StateSwitcher.StateSwitcher<InputMoveState>();
            }
        }
    }
}