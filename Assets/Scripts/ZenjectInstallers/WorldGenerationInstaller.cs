using InspectorAddons;
using PirateIsland.World;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class WorldGenerationInstaller : MonoInstaller
    {
        [SerializeField] private InterfaceObject<ITileWorld, Object> _tileWorldComponent;
        [SerializeField] private InterfaceObject<IHeightMapFactory, Object> _heightMapFactory;
        [SerializeField] private InterfaceObject<ITilesInfoProvider, Object> _tilesInfoProvider;

        public override void InstallBindings()
        {
            Container.Bind<ITileWorld>().FromInstance(_tileWorldComponent.Interface);
            Container.Bind<ITilesInfoProvider>().FromInstance(_tilesInfoProvider.Interface);
            Container.Bind<IHeightMapFactory>().FromInstance(_heightMapFactory.Interface);
            Container.Bind<IWorldGenerator>().To<WorldGenerator>().AsSingle();
        }
    }
}
