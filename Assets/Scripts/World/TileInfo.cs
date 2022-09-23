using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PirateIsland.World
{
    /// <summary>
    /// If you put this type in an array, it will look like a dictionary. 
    /// Created as a trick for the inspector to not display a dictionary by default.
    /// </summary>
    [Serializable]
    public class TileInfo
    {
        [SerializeField] private TileBase _tile;
        [Min(0)]
        [SerializeField] private Vector2 _heightRange;
        [SerializeField] private bool _haveCollider = false;

        public TileInfo(TileBase tile, Vector2 heightRange)
        {
            _tile = tile;
            _heightRange = heightRange;
        }

        public Vector2 HeightRange { get => _heightRange; }
        public TileBase Tile { get => _tile; }
        public bool HaveCollider { get => _haveCollider; }
    }
}
