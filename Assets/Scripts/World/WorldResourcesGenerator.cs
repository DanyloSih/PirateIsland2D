using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PirateIsland.World
{
    public class WorldResourcesGenerator : IWorldResourcesGenerator
    {
        private List<WorldResource> _spawnedResources = new List<WorldResource>();
        private DiContainer _container;
        private ITileWorld _tileWorld;
        private IWorldResourcesProvider _worldResourcesProvider;
        private GameObject _root;

        [Inject]
        public void Construct(
            DiContainer diContainer,
            ITileWorld tileWorld,
            IWorldResourcesProvider worldResourcesProvider)
        {
            _container = diContainer;
            _tileWorld = tileWorld;
            _worldResourcesProvider = worldResourcesProvider;

            if (_root == null)
                _root = new GameObject("|__ResourcesRoot__|");
        }

        public void GenerateResources()
        {
            DestroySpawnedObjects();
            BoundsInt bounds = _tileWorld.GetWorldBounds();

            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                for (int x = bounds.xMin; x < bounds.xMax; x++)
                {
                    WorldResource spawnedResource;
                    if (TrySpawnResource(x, y, out spawnedResource))
                        _spawnedResources.Add(spawnedResource);
                }
            }
        }

        private bool TrySpawnResource(int x, int y, out WorldResource spawnedResource)
        {
            spawnedResource = null;
            TileInfo tileInfo = _tileWorld.GetTile(new Vector2(x, y));

            if (tileInfo.HaveCollider)
                return false;

            foreach (WorldResource item in _worldResourcesProvider.GetResources())
            {
                Vector2 placePosition = GetPlacePosition(item.Info, x, y);
                float minDistance = item.Info.MinDistanceToOtherResource;
                if (UnityEngine.Random.Range(0f, 1f) <= item.Info.SpawnChance
                 && IsRangeIntersect(tileInfo.HeightRange, item.Info.HeightRange)
                 && !IsOtherResourceNearestThenMinDistance(placePosition, minDistance))
                {
                    spawnedResource = Create(item);
                    GameObject resourceObject = spawnedResource.GameObject;
                    resourceObject.transform.position = placePosition;
                    resourceObject.transform.rotation = GetPlaceRotation(item.Info);
                    resourceObject.transform.SetParent(_root.transform);
                    return true;
                }
            }

            return false;
        }

        private Vector2 GetPlacePosition(WorldResourceInfo info, int x, int y)
            => new Vector2(x, y) + Vector2.one / 2f +
               new Vector2(UnityEngine.Random.Range(-info.OffsetRange.x, info.OffsetRange.x),
                           UnityEngine.Random.Range(-info.OffsetRange.y, info.OffsetRange.y));

        private Quaternion GetPlaceRotation(WorldResourceInfo info)
            => Quaternion.Euler(0, 0,
                UnityEngine.Random.Range(info.RotationRange.x, info.RotationRange.y));

        private bool IsOtherResourceNearestThenMinDistance(Vector2 origin, float minDistance)
        {
            foreach (var resource in _spawnedResources)
                if (Vector3.Distance(origin, resource.GameObject.transform.position) < minDistance)
                    return true;

            return false;
        }

        private void DestroySpawnedObjects()
        {
            foreach (var item in _spawnedResources)
                MonoBehaviour.Destroy(item.GameObject);

            _spawnedResources.Clear();
        }

        private bool IsRangeIntersect(Vector2 aRange, Vector2 bRange)
        {
            return Mathf.Clamp(bRange.x, aRange.x, aRange.y) == bRange.x
                || Mathf.Clamp(bRange.y, aRange.x, aRange.y) == bRange.y;
        }

        private WorldResource Create(WorldResource resource)
        {
            return new WorldResource(
                resource.Info,
                _container.InstantiatePrefab(resource.GameObject));
        }
    }
}