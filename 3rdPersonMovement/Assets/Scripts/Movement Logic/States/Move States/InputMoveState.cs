using ATGStateMachine;
using InputService;
using Movement.Interfaces;
using UnityEngine;

namespace MovementLogic.States
{
    public class InputMoveState: BaseStatement<IMovable>
    {
        private readonly float _smooth;

        private readonly IInputable _inputService;
        
        private Vector3 _targetDirection;
        private Vector3 _lastDirection;
        private Vector3 _movementVector;
        
        private float _lerpTime;
        
        public InputMoveState(IMovable mainObject, IStateSwitcher<IMovable> stateSwitcher, 
            IInputable inputable,float smooth) 
            : base(mainObject, stateSwitcher)
        {
            _inputService = inputable;
            _smooth = smooth;
        }

        public override void Enter()
        {
            MainObject.AnimatorService.AnimateMove();
        }

        public override void Execute()
        {
            var inputDir = _inputService.JoystickValue;
            
            if (IsZeroInput(inputDir)) return;

            _movementVector = 
                new Vector3(inputDir.x, 0f, inputDir.y).normalized;
            
            if (Vector3.Distance(_movementVector, _lastDirection) <= Mathf.Epsilon)
            {
                _lerpTime = 1f;
            }
            _lastDirection = _movementVector;

            float smoothTime = Mathf.Clamp01(_lerpTime * (1 - _smooth));
            
            _targetDirection = 
                Vector3.Lerp(_targetDirection, _movementVector, smoothTime);
            
            MainObject.MoveService.Move(_targetDirection);
            MainObject.MoveService.Rotate(_targetDirection,smoothTime);

            _lerpTime += Time.deltaTime;
        }

        private bool IsZeroInput(in Vector2 input)
        {
            if (!input.Equals(Vector2.zero)) return false;
            StateSwitcher.StateSwitcher<InputIdleState>();
            return true;
        } 
    }
}