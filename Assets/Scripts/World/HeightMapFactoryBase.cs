using System;
using UnityEngine;

namespace PirateIsland.World
{
    public abstract class HeightMapFactoryBase : MonoBehaviour, IHeightMapFactory
    {
        [SerializeField] private Vector2Int _heightMapSize;

        public Vector2Int HeightMapSize { get => _heightMapSize; }

        public float[,] CreateHeightMap()
        {
            float[,] map = new float[_heightMapSize.y, _heightMapSize.x];
            OnHeightMapCreating();

            for (int y = 0; y < _heightMapSize.y; y++)
            {
                for (int x = 0; x < _heightMapSize.x; x++)
                {
                    map[y, x] = GetHeightMapPointSample(y, x);
                }
            }

            OnHeightMapCreated(map);
            return map;
        }


        protected virtual void OnHeightMapCreating() { }

        protected virtual float GetHeightMapPointSample(int y, int x) { return 0; }

        protected virtual void OnHeightMapCreated(float[,] map) { }
        
    }
}