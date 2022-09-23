using UnityEngine;
using UnityEngine.Tilemaps;

namespace PirateIsland.World
{
    public class TileLayer : MonoBehaviour, ITileLayer
    {
        [SerializeField] private Tilemap _tilemap;

        public BoundsInt GetLayerBounds()
            => _tilemap.cellBounds;

        public void Clear()
            => _tilemap.ClearAllTiles();

        public TileBase GetTile(Vector2 position)
            => _tilemap.GetTile(ConvertToVector3Int(position));

        public void SetTile(TileBase tile, Vector2 position)
            => _tilemap.SetTile(ConvertToVector3Int(position), tile);

        private Vector3Int ConvertToVector3Int(Vector2 vector2)
            => new Vector3Int(
                Mathf.RoundToInt(vector2.x),
                Mathf.RoundToInt(vector2.y));
    }
}
