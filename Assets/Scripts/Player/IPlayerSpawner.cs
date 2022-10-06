using UnityEngine;

namespace PirateIsland.Player
{
    public interface IPlayerSpawner
    {
        bool IsPlayerSpawned { get; }
        GameObject SpawnedPlayer { get; }
        Vector3 SpawnPosition { get; }

        GameObject SpawnPlayer();
    }
}