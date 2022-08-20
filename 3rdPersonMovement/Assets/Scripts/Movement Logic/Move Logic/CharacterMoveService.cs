using UnityEngine;
using Zenject;

namespace BotMovement.MoveLogic
{
    public class CharacterMoveService: MoveService, ITickable
    {
        private readonly float _moveSpeed;
        
        private readonly CharacterController _character;
        private readonly Transform _characterTransform;

        public CharacterMoveService(CharacterController controller, float moveSpeed)
        {
            _character = controller;
            _characterTransform = _character.transform;

            _moveSpeed = moveSpeed;
        }
        
        public override void Move(Vector3 direction)
        {
            _character.Move(direction * _moveSpeed * Time.deltaTime);
        }

        public override void Rotate(Vector3 direction, float smoothTime)
        {
            var isNeedRotate = Vector3.Distance(direction, Vector3.zero) >= Mathf.Epsilon;

            if (isNeedRotate)
            {
                _characterTransform.rotation = Quaternion.Lerp(_characterTransform.rotation,
                    Quaternion.LookRotation(direction),smoothTime);
            }
        }

        public void Tick()
        {
            if (!_character.isGrounded)
            {
                _character.Move(10f*Vector3.down * Time.deltaTime);
            }
        }
    }
}