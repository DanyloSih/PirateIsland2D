using System;
using UnityEngine;

namespace PirateIsland.World
{
    [Serializable]
    public class WorldResource
    {
        [SerializeField] private WorldResourceInfo _info;
        [SerializeField] private GameObject _gameObject;

        public WorldResource(WorldResourceInfo info, GameObject gameObject)
        {
            _info = info;
            _gameObject = gameObject;
        }

        public WorldResourceInfo Info { get => _info; }
        public GameObject GameObject { get => _gameObject; }
    }
}