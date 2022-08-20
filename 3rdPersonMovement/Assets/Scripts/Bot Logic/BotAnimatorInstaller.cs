using UnityEngine;
using Zenject;

namespace BotLogic
{
    public class BotAnimatorInstaller: MonoInstaller
    {
        [SerializeField] private BotAnimatorService _botAnimator;

        public override void InstallBindings()
        {
            Container.BindInstance(_botAnimator).AsSingle();
        }
    }
}