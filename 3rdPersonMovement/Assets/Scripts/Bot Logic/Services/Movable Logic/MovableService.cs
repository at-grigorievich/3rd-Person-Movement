using UnityEngine;

namespace BotLogic.Movable
{
    public abstract class MovableService : MonoBehaviour
    {
        public abstract void Move(Vector3 direction);
        public abstract void Rotate(Vector3 direction, float smoothTime);
    }
}