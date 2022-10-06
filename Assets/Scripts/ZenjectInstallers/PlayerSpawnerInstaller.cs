using InspectorAddons;
using PirateIsland.Player;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class PlayerSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private InterfaceComponent<IPlayerSpawner> _playerSpawnerComponent;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerSpawner>().FromInstance(_playerSpawnerComponent.Interface);
        }
    }
}
