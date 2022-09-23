using InspectorAddons;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace PirateIsland.World
{
    public class TileWorld : MonoBehaviour, ITileWorld
    {
        [SerializeField] private InterfaceComponent<ITileLayer> _nonColliderLayerComponent;
        [SerializeField] private InterfaceComponent<ITileLayer> _colliderLayerComponent;

        private ITileLayer _nonColliderLayer;
        private ITileLayer _colliderLayer;
        private ITilesInfoProvider _tilesInfoProvider;

        [Inject]
        public void Construct(ITilesInfoProvider tilesInfoProvider)
        {
            _nonColliderLayer = _nonColliderLayerComponent.Interface;
            _colliderLayer = _colliderLayerComponent.Interface;
            _tilesInfoProvider = tilesInfoProvider;
        }

        public BoundsInt GetWorldBounds()
        {
            BoundsInt nonColliderLayerBounds = _nonColliderLayer.GetLayerBounds();
            BoundsInt colliderLayerBounds = _colliderLayer.GetLayerBounds();

            int xMin = Mathf.Min(colliderLayerBounds.xMin, nonColliderLayerBounds.xMin);  
            int xMax = Mathf.Max(colliderLayerBounds.xMax, nonColliderLayerBounds.xMax);  
            int yMin = Mathf.Min(colliderLayerBounds.yMin, nonColliderLayerBounds.yMin);  
            int yMax = Mathf.Max(colliderLayerBounds.yMax, nonColliderLayerBounds.yMax);  
            int zMin = Mathf.Min(colliderLayerBounds.zMin, nonColliderLayerBounds.zMin);
            int zMax = Mathf.Max(colliderLayerBounds.zMax, nonColliderLayerBounds.zMax);

            BoundsInt result = new BoundsInt();

            result.xMin = xMin;
            result.xMax = xMax;
            result.yMin = yMin;
            result.yMax = yMax;
            result.zMin = zMin;
            result.zMax = zMax;
            return result;
        }

        public TileInfo GetTile(Vector2 position)
        {
            TileBase tile = _nonColliderLayer.GetTile(position)??_colliderLayer.GetTile(position);

            if (tile != null)
                foreach (TileInfo tileInfo in _tilesInfoProvider.GetTilesInfo())
                    if (tileInfo.Tile == tile)
                        return tileInfo;

            return null;
        }

        public void SetTile(TileInfo tileInfo, Vector2 position)
        {
            if (tileInfo.HaveCollider)
                _colliderLayer.SetTile(tileInfo.Tile, position);
            else
                _nonColliderLayer.SetTile(tileInfo.Tile, position);
        }

        public void Clear()
        {
            _nonColliderLayer.Clear();
            _colliderLayer.Clear();
        }
    }
}
