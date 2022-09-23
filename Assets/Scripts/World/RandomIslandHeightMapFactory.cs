using UnityEngine;
using UnityEngine.UIElements;

namespace PirateIsland.World
{
    public class RandomIslandHeightMapFactory : HeightMapFactoryBase
    {
        [SerializeField] private PerlinNoiseProvider _perlinNoiseProvider;
        [SerializeField] private float _radius = 9f;
        [SerializeField] private float _hillHeighMultiplier = 1.5f;

        private Vector2 _perlinNoiseOrigin;
        private Vector2 _islandOrigin;

        protected override void OnHeightMapCreating()
        {
            _perlinNoiseOrigin = _perlinNoiseProvider.GetRandomOrigin();

            Vector2 heightMapSize = new Vector2(HeightMapSize.x, HeightMapSize.y);
            _islandOrigin = heightMapSize / 2;
        }

        protected override float GetHeightMapPointSample(int y, int x)
        {
            float perlinNoiseSample = _perlinNoiseProvider.GetPerlinNoiseSample(
                _perlinNoiseOrigin,
                HeightMapSize,
                _perlinNoiseProvider.PerlinNoiseScale,
                x,
                y);

            float distance = Vector2.Distance(_islandOrigin, new Vector2(x, y));
            float normalizedDistance = Mathf.Clamp(distance / _radius, 0f, 1f);

            return Mathf.Clamp(perlinNoiseSample * _hillHeighMultiplier, 0f, 1f) * (1 - normalizedDistance);
        }

        private Vector2 GetRandomIslandOrigin()
        {
            float theta = Random.Range(0, Mathf.PI * 2f);
            Vector2 distance = new Vector2(
                Random.Range(0, HeightMapSize.x / 2 - _radius),
                Random.Range(0, HeightMapSize.y / 2 - _radius));

            return new Vector2(
                HeightMapSize.x / 2 + Mathf.Cos(theta) * distance.x,
                HeightMapSize.y / 2 + Mathf.Sin(theta) * distance.y);
        }
    }
}