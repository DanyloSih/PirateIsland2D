using InspectorAddons;
using PirateIsland.World;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class WorldResourcesGenerationInstaller : MonoInstaller
    {
        [SerializeField] private InterfaceObject<IWorldResourcesProvider, Object> _resourcesProviderComponent;

        public override void InstallBindings()
        {
            Container.Bind<IWorldResourcesProvider>()
                .FromInstance(_resourcesProviderComponent.Interface);

            Container.Bind<IWorldResourcesGenerator>().To<WorldResourcesGenerator>().AsSingle();
        }
    }
}
