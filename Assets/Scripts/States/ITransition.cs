namespace PirateIsland.States
{
    public interface ITransition : IEnterableObject<StateSwitchHandler>
    {
        IState NextState { get; set; }
    }
}