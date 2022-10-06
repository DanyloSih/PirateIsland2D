namespace PirateIsland.States
{
    public interface IStatesMachine
    {
        void SwitchState(IState state);
    }
}