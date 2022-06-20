using System;
using BotLogic.States;
using PlayerLogic.Interfaces;
using UnityEngine;
using Zenject;

namespace BotLogic
{
    public class PlayerBotLogicService: BotLogicService
    {
        [Range(0f, 0.99f)] 
        [SerializeField] private float smoothing = 0.25f;

        [Inject]
        private void Constructor(IInputable inputService)
        {
            var movementLogic = 
                new PlayerMovementBehaviour(inputService, MovementService, smoothing);

            Func<bool> tryToMove = () => inputService.JoystickValue.magnitude > 0.05f;


            AllStates.Add(new IdleBotState(this,this,tryToMove));
            AllStates.Add(new MoveBotState(this,this,movementLogic));
        }

        private void Start()
        {
            InitStartState();
            OnState();
        }
    }
}