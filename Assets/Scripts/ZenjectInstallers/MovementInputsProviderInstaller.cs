using PirateIsland.Player;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class MovementInputsProviderInstaller : MonoInstaller
    {
        [SerializeField] private MovementInputsProvider _movementController;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MovementInputsProvider>()
                .FromInstance(_movementController)
                .AsSingle();
        }
    }
}
