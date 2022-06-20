using BotLogic.Services;
using UnityEngine;
using Zenject;

namespace BotLogic.Zenject
{
    public class BotAnimatorInstaller: MonoInstaller
    {
        [SerializeField] private BotLogicAnimator _botAnimator;

        public override void InstallBindings()
        {
            Container.BindInstance(_botAnimator).AsSingle().NonLazy();
        }
    }
}