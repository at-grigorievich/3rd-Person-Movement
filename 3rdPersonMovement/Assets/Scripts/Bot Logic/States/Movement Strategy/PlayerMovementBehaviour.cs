using ATGStateMachine;
using BotLogic.Movable;
using PlayerLogic.Interfaces;
using UnityEngine;

namespace BotLogic.States
{
    public class PlayerMovementBehaviour: MovementStateBehaviour
    {
        private readonly IInputable _inputService;
        private readonly MovableService _movableService;
        
        private readonly float _smoothing;
        
        private Vector3 _targetDirection;
        private Vector3 _lastDirection;
        private Vector3 _movementVector;
        
        private float _lerpTime;

        public PlayerMovementBehaviour(IInputable inputService, MovableService movableService,
            float smoothing)
        {
            _inputService = inputService;
            _movableService = movableService;

            _smoothing = smoothing;
        }
        
        public override void Enter()
        {
            _mainObject.AgentAnimator.AnimateMove();
        }

        public override void Execute()
        {
            Vector2 input = _inputService.JoystickValue;

            if (!CheckZeroInput(input))
                return;

            _movementVector = 
                new Vector3(input.x, 0f, input.y).normalized;
            
            if (Vector3.Distance(_movementVector, _lastDirection) <= Mathf.Epsilon)
            {
                _lerpTime = 1f;
            }
            _lastDirection = _movementVector;

            float smoothTime = Mathf.Clamp01(_lerpTime * (1 - _smoothing));
            
            _targetDirection = 
                Vector3.Lerp(_targetDirection, _movementVector, smoothTime);


            _movableService.Move(_targetDirection);
            _movableService.Rotate(_targetDirection,smoothTime);

            _lerpTime += Time.deltaTime;
        }

        public override void Exit() {}
        
        private bool CheckZeroInput(Vector2 input)
        {
            if (input.Equals(Vector2.zero))
            {
                ((IStateSwitcher)_mainObject).StateSwitcher<IdleBotState>();
                return false;
            }
            return true;
        }
    }
}