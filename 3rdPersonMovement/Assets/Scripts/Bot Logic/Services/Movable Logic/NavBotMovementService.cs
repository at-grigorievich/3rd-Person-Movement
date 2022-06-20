using System;
using BotLogic.Movable;
using UnityEngine;
using UnityEngine.AI;

namespace BotLogic.Services
{
    public class NavBotMovementService : MovableService
    {
        [SerializeField] private NavMeshAgent _navAgent;

        private void Awake()
        {
            if (_navAgent == null)
                throw new NullReferenceException("Cant setup navigation agent !");
        }

        public override void Move(Vector3 direction)
        {
            Vector3 resDirection = direction * _navAgent.speed * Time.deltaTime;
            _navAgent.Move(resDirection);
        }

        public override void Rotate(Vector3 direction,float smoothTime)
        {
            bool isNeedRotate = Vector3.Distance(direction, Vector3.zero) >= Mathf.Epsilon;

            Transform agent = _navAgent.transform;
            if (isNeedRotate)
            {
                agent.rotation = Quaternion.Lerp(agent.rotation,
                    Quaternion.LookRotation(direction),smoothTime);
            }
        }
    }
}