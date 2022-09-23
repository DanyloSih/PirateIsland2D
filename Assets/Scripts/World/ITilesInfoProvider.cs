using System.Collections.Generic;

namespace PirateIsland.World
{
    public interface ITilesInfoProvider
    {
        IEnumerable<TileInfo> GetTilesInfo();
        TileInfo GetTileInfoByHeight(float height);
    }
}