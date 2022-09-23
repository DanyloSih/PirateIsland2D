using InspectorAddons;
using PirateIsland.World;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class WorldGenerationInstaller : MonoInstaller
    {
        [SerializeField] private InterfaceComponent<ITileWorld> _tileWorldComponent;
        [SerializeField] private InterfaceComponent<IHeightMapFactory> _heightMapFactory;
        [SerializeField] private InterfaceScrptableObject<ITilesInfoProvider> _tilesInfoProvider;

        public override void InstallBindings()
        {
            Container.Bind<ITileWorld>().FromInstance(_tileWorldComponent.Interface);
            Container.Bind<ITilesInfoProvider>().FromInstance(_tilesInfoProvider.Interface);
            Container.Bind<IHeightMapFactory>().FromInstance(_heightMapFactory.Interface);
            Container.Bind<IWorldGenerator>().To<WorldGenerator>().AsSingle();
        }
    }
}
