using ATGStateMachine;
using BotLogic.Movable;
using BotLogic.Services;
using UnityEngine;
using Zenject;

namespace BotLogic
{
    public class BotLogicService: StatementBehaviour<IAgent>,IAgent
    {
        [Inject]
        public BotLogicAnimator AgentAnimator { get; private set; }
        [Inject]
        public MovableService MovementService { get; private set; }

        public Transform AgentTransform => transform;

        private void Update()
        {
            OnExecute();
        }

        public class Factory: PlaceholderFactory<UnityEngine.Object,BotLogicService>{}
    }
}