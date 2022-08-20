using BotMovement.MoveLogic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace MovementLogic.Installers
{
    public class InputNavMoveInstaller: MonoInstaller
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _smooth;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_smooth).AsSingle();
            Container.Bind<MoveService>().FromInstance(new NavMoveService(_agent)).AsSingle();
            Container.BindInterfacesAndSelfTo<InputMoveLogic>().AsSingle().NonLazy();
        }
    }
}