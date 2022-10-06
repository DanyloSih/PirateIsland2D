using System;
using PirateIsland.World;
using UnityEngine;
using Zenject;

namespace PirateIsland.Player
{
    public class PlayerSpawner : MonoBehaviour, IPlayerSpawner
    {
        [SerializeField] private GameObject _playerPrefab;

        private Vector3 _spawnPosition;
        private GameObject _spawnedPlayer;
        private DiContainer _container;
        private ITileWorld _tileWorld;

        [Inject]
        public void Construct(DiContainer container, ITileWorld tileWorld)
        {
            _container = container;
            _tileWorld = tileWorld;
        }

        public bool IsPlayerSpawned { get => _spawnedPlayer != null; }
        public GameObject SpawnedPlayer { get => _spawnedPlayer; }
        public Vector3 SpawnPosition { get => _spawnPosition; }

        public GameObject SpawnPlayer()
        {
            if (IsPlayerSpawned)
                throw new Exception("Player is already spawned!");

            _spawnedPlayer = _container.InstantiatePrefab(_playerPrefab);
            _spawnPosition = CalculateSpawnPosition();
            _spawnedPlayer.transform.position = _spawnPosition;
            return _spawnedPlayer;
        }

        private Vector3 CalculateSpawnPosition()
        {
            float angle = UnityEngine.Random.Range(0f, 360f);
            Vector2 direction = new Vector2(
                Mathf.Sin(Mathf.Deg2Rad * angle),
                Mathf.Cos(Mathf.Deg2Rad * angle));

            BoundsInt bounds = _tileWorld.GetWorldBounds();
            Vector2 offsetBoundsOffset = new Vector2(bounds.xMin, bounds.yMin);
            Vector2 startPosition
                = Vector2.Scale(new Vector2(bounds.size.x, bounds.size.y), -direction / 2f);

            float x = startPosition.x;
            float y = startPosition.y;
            for (; y < bounds.yMax && x < bounds.xMax; x += direction.x, y += direction.y)
            {
                TileInfo tileInfo = _tileWorld.GetTile(new Vector2(x, y));
                if (tileInfo == null)
                    continue;

                if (!tileInfo.HaveCollider)
                    return new Vector3(x + 0.5f, y + 0.5f, 0);
            }

            throw new Exception("A cell suitable for the player's spawn was not found!");
        }
    }
}
