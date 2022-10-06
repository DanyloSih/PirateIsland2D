using UnityEngine;

namespace PirateIsland.Player
{
    public interface IMovementPointerPositionProvider
    {
        Vector2 GetPointerPosition();
    }
}