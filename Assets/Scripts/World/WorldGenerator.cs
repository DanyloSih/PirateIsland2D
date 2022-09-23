using UnityEngine;
using Zenject;

namespace PirateIsland.World
{
    public class WorldGenerator : IWorldGenerator
    {
        private ITilesInfoProvider _tilesInfoProvider;
        private ITileWorld _tileWorld;
        private IHeightMapFactory _heightMapFactory;

        public WorldGenerator(
            ITilesInfoProvider tilesInfoProvider,
            ITileWorld tileWorld,
            IHeightMapFactory heightMapFactory)
        {
            _tilesInfoProvider = tilesInfoProvider;
            _tileWorld = tileWorld;
            _heightMapFactory = heightMapFactory;
        }

        public void GenerateWorld()
        {
            _tileWorld.Clear();

            float[,] heightMap = _heightMapFactory.CreateHeightMap();
            Vector2 heightMapSize = new Vector2(
                heightMap.GetLength(1),
                heightMap.GetLength(0));

            int halfHeight = (int)(heightMapSize.y / 2);
            int halfWidth = (int)(heightMapSize.x / 2);

            for (int y = 0; y < heightMapSize.y; y++)
            {
                for (int x = 0; x < heightMapSize.x; x++)
                {
                    float height = heightMap[y, x];
                    var tileInfo = _tilesInfoProvider.GetTileInfoByHeight(height);
                    _tileWorld.SetTile(tileInfo, new Vector2(x - halfWidth, y - halfHeight));
                }
            }
        }
    }
}
