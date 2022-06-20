using BotLogic.Movable;
using UnityEngine;
using Zenject;

namespace BotLogic.Zenject
{
    public class BotMovableInstaller: MonoInstaller
    {
        [SerializeField] private MovableService _movableService;

        public override void InstallBindings()
        {
            Container.BindInstance(_movableService).AsSingle().NonLazy();
        }
    }
}