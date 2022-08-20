using BotMovement.MoveLogic;
using UnityEngine;
using Zenject;

namespace MovementLogic.Installers
{
    public class InputCharacterMoveInstaller: MonoInstaller
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _smooth;
        [SerializeField] private float _moveSpeed;

        public override void InstallBindings()
        {
            Container.BindInstance(_smooth).AsSingle();

            Container.Bind(typeof(ITickable), typeof(MoveService))
                .FromInstance(new CharacterMoveService(_characterController, _moveSpeed))
                .AsSingle();

            Container.BindInterfacesAndSelfTo<InputMoveLogic>().AsSingle().NonLazy();
        }
    }
}