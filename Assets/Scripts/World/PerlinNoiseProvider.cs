using System;
using UnityEngine;

namespace PirateIsland.World
{
    [Serializable]
    public class PerlinNoiseProvider
    {
        [SerializeField] private Vector2 _originScatter = new Vector2(200f, 200f);
        [SerializeField] private float _perlinNoiseScale;

        public PerlinNoiseProvider(Vector2 originScatter, float perlinNoiseScale)
        {
            _originScatter = originScatter;
            _perlinNoiseScale = perlinNoiseScale;
        }

        public Vector2 OriginScatter { get => _originScatter; }
        public float PerlinNoiseScale { get => _perlinNoiseScale; }

        public float GetPerlinNoiseSample(
            Vector2 origin,
            Vector2 heightMapSize,
            float scale,
            int x,
            int y)
        {
            float xCoord = (float)(origin.x + x) / heightMapSize.x * scale;
            float yCoord = (float)(origin.y + y) / heightMapSize.y * scale;
            return Mathf.PerlinNoise(xCoord, yCoord);
        }

        public Vector2 GetRandomOrigin()
            => new Vector2(
                UnityEngine.Random.Range(-OriginScatter.x, OriginScatter.x),
                UnityEngine.Random.Range(-OriginScatter.y, OriginScatter.y));
    }
}