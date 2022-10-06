using UnityEngine;

namespace PirateIsland.Player
{
    public interface IMovementInputsReceiver
    {
        void OnMovementStart();
        void OnMovementStop();
        void OnMovePointerUpdated(Vector2 newPoistion);
    }
}