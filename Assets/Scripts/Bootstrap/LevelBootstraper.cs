using PirateIsland.Player;
using PirateIsland.World;
using UnityEngine;
using Zenject;

namespace PirateIsland.Bootstrap
{
    public class LevelBootstraper : MonoBehaviour
    {
        private IWorldGenerator _worldGenerator;
        private IWorldResourcesGenerator _worldResourcesGenerator;
        private IPlayerSpawner _playerSpawner;

        [Inject]
        public void Construct(
            IWorldGenerator worldGenerator,
            IWorldResourcesGenerator worldResourcesGenerator, 
            IPlayerSpawner playerSpawner)
        {
            _worldGenerator = worldGenerator;
            _worldResourcesGenerator = worldResourcesGenerator;
            _playerSpawner = playerSpawner;
        }

        public void Awake()
        {
            _worldGenerator.GenerateWorld();
            _worldResourcesGenerator.GenerateResources();
            if(!_playerSpawner.IsPlayerSpawned)
                _playerSpawner.SpawnPlayer();
        }
    }
}
