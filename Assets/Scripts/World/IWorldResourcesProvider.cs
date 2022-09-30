using System.Collections.Generic;

namespace PirateIsland.World
{
    public interface IWorldResourcesProvider
    {
        IEnumerable<WorldResource> GetResources();
    }
}