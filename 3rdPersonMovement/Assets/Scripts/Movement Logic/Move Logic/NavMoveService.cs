using UnityEngine;
using UnityEngine.AI;

namespace BotMovement.MoveLogic
{
    public class NavMoveService: MoveService
    {
        private readonly NavMeshAgent _agent;
        private readonly Transform _agentTransform;
        
        public NavMoveService(NavMeshAgent agent)
        {
            _agent = agent;
            _agentTransform = _agent.transform;
        }
        
        public override void Move(Vector3 direction)
        {
            var resDirection = direction * _agent.speed * Time.deltaTime;
            _agent.Move(resDirection);
        }

        public override void Rotate(Vector3 direction, float smoothTime)
        {
            var isNeedRotate = Vector3.Distance(direction, Vector3.zero) >= Mathf.Epsilon;

            if (isNeedRotate)
            {
                _agentTransform.rotation = Quaternion.Lerp(_agentTransform.rotation,
                    Quaternion.LookRotation(direction),smoothTime);
            }
        }
    }
}