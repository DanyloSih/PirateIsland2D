using PirateIsland.Core;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class CoroutineExecutorInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineExecutor _coroutineExecutor;

        public override void InstallBindings()
        {
            Container.Bind<ICoroutineExecutor>()
                .To<CoroutineExecutor>()
                .FromInstance(_coroutineExecutor);
        }
    }
}
