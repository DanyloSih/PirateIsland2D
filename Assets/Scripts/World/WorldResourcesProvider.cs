using System.Collections.Generic;
using UnityEngine;

namespace PirateIsland.World
{
    [CreateAssetMenu(menuName = "World/new ResourceProvider", fileName = "WorldResourceProvider")]
    public class WorldResourcesProvider : ScriptableObject, IWorldResourcesProvider
    {
        [SerializeField] private List<WorldResource> _resources;

        public IEnumerable<WorldResource> GetResources() => _resources;
    }
}