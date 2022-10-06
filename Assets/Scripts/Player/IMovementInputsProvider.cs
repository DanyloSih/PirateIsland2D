namespace PirateIsland.Player
{
    public interface IMovementInputsProvider
    {
        void AddListner(IMovementInputsReceiver movementController);
        void RemoveListner(IMovementInputsReceiver movementController);
    }
}