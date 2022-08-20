using UnityEngine;

namespace BotMovement.MoveLogic
{
    public abstract class MoveService
    {
        public abstract void Move(Vector3 direction);
        public abstract void Rotate(Vector3 direction, float smoothTime);
    }
}