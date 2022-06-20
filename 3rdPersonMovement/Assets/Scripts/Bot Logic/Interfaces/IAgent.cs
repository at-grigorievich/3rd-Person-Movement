using BotLogic.Movable;
using BotLogic.Services;
using UnityEngine;

namespace BotLogic
{
    public interface IAgent
    {
        Transform AgentTransform { get; }
        
        BotLogicAnimator AgentAnimator { get; }
        MovableService MovementService { get; }
    }
}