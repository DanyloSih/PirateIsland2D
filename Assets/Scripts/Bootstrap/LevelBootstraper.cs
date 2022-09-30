using PirateIsland.World;
using UnityEngine;
using Zenject;

namespace PirateIsland.Bootstrap
{
    public class LevelBootstraper : MonoBehaviour
    {
        private IWorldGenerator _worldGenerator;
        private IWorldResourcesGenerator _worldResourcesGenerator;

        [Inject]
        public void Construct(
            IWorldGenerator worldGenerator,
            IWorldResourcesGenerator worldResourcesGenerator)
        {
            _worldGenerator = worldGenerator;
            _worldResourcesGenerator = worldResourcesGenerator;
        }

        public void Awake()
        {
            _worldGenerator.GenerateWorld();
            _worldResourcesGenerator.GenerateResources();
        }
    }
}
