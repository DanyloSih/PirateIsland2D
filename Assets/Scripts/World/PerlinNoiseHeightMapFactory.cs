using UnityEngine;

namespace PirateIsland.World
{
    public class PerlinNoiseHeightMapFactory : HeightMapFactoryBase
    {
        [SerializeField] private PerlinNoiseProvider _perlinNoiseProvider;

        private Vector2 _perlinNoiseOrigin;

        protected override float GetHeightMapPointSample(int y, int x)
        {
            return _perlinNoiseProvider.GetPerlinNoiseSample(
                _perlinNoiseOrigin,
                HeightMapSize,
                _perlinNoiseProvider.PerlinNoiseScale,
                x,
                y);
        }

        protected override void OnHeightMapCreating()
        {
            _perlinNoiseOrigin = _perlinNoiseProvider.GetRandomOrigin();
        }
    } 
}