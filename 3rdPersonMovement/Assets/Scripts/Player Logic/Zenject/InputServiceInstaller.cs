using PlayerLogic.Interfaces;
using PlayerLogic.Services;
using UnityEngine;
using Zenject;

namespace PlayerLogic.Zenject
{
    public class InputServiceInstaller: MonoInstaller
    {
        [SerializeField] private PlayerInputService _inputService;

        public override void InstallBindings()
        {
            Container.Bind<IInputable>()
                .FromInstance(_inputService)
                .AsSingle().NonLazy();
        }
    }
}