using UnityEngine;
using UnityEngine.Tilemaps;

namespace PirateIsland.World
{
    public interface ITileLayer
    {
        public BoundsInt GetLayerBounds();
        public void SetTile(TileBase tile, Vector2 position);
        public TileBase GetTile(Vector2 position);
        public void Clear();
    }
}