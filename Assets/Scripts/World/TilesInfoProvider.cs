using System.Collections.Generic;
using PirateIsland.Exceptions;
using UnityEngine;

namespace PirateIsland.World
{
    [CreateAssetMenu(menuName = "World/new TilesInfoProvider", fileName = "TilesInfoProvider")]
    public class TilesInfoProvider : ScriptableObject, ITilesInfoProvider
    {
        [SerializeField] private List<TileInfo> _tilesInfo = new List<TileInfo>(2);

        public TileInfo GetTileInfoByHeight(float height)
        {
            var tileInfo = _tilesInfo.Find(
                x => height >= Mathf.Min(x.HeightRange.x, x.HeightRange.y)
                  && height <= Mathf.Max(x.HeightRange.x, x.HeightRange.y));

            if (tileInfo == null)
                tileInfo = height <= 0 
                    ? _tilesInfo[0] 
                    : _tilesInfo[_tilesInfo.Count - 1];

            return tileInfo;
        }

        public IEnumerable<TileInfo> GetTilesInfo()
            => _tilesInfo;

        protected void OnEnable()
        {
            if (_tilesInfo.Count < 2)
            {
                _tilesInfo.AddRange(new TileInfo[2 - _tilesInfo.Count]);
                throw new IncorrectInspectorFieldValueException(
                    nameof(_tilesInfo),
                    "List length must be greater than or equal to 2");
            }
        }
    }
}
