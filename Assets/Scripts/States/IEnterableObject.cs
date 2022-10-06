namespace PirateIsland.States
{
    public interface IEnterableObject<TArgument> where TArgument : class
    {
        void Enter(TArgument context);
        void Exit();
    }
}