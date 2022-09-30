using System;
using UnityEngine;

namespace PirateIsland.World
{
    [Serializable]
    public class WorldResourceInfo
    {
        [Min(0)]
        [SerializeField] private float _minDistanceToOtherResource = 0;

        [Range(0, 1)]
        [SerializeField] private float _spawnChance = 0.76f;

        [Min(0)]
        [SerializeField] private Vector2 _rotationRange;
        
        [Tooltip("Determines for each axis how much the resource " +
            "can be displaced from the position of its tile.")]
        [Min(0)]
        [SerializeField] private Vector2 _offsetRange;

        [Tooltip("The height range within which this resource can appear.")]
        [Min(0)]
        [SerializeField] private Vector2 _heightRange;

        public WorldResourceInfo(
            float minDistanceToOtherResource,
            float spawnChance,
            Vector2 offsetRange,
            Vector2 heightRange)
        {
            _minDistanceToOtherResource = minDistanceToOtherResource;
            _spawnChance = spawnChance;
            _offsetRange = offsetRange;
            _heightRange = heightRange;
        }

        public float MinDistanceToOtherResource { get => _minDistanceToOtherResource; }

        /// <summary>
        /// Determines for each axis how much the resource can be displaced 
        /// from the position of its tile.
        /// </summary>
        public Vector2 OffsetRange { get => _offsetRange; }

        /// <summary>
        /// The height range within which this resource can appear.
        /// </summary>
        public Vector2 HeightRange { get => _heightRange; }

        public float SpawnChance { get => _spawnChance; }

        public Vector2 RotationRange { get => _rotationRange; }
    }
}