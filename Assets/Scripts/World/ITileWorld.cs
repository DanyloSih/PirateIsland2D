using UnityEngine;

namespace PirateIsland.World
{
    public interface ITileWorld
    {
        public void SetTile(TileInfo tileInfo, Vector2 position);
        public TileInfo GetTile(Vector2 position);
        public void Clear();
    }
}
