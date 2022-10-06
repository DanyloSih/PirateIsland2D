namespace PirateIsland.States
{
    public abstract class Transition : EnterableObject<StateSwitchHandler>, ITransition
    {
        public IState NextState { get; set; }

        protected Transition(IState nextState)
        {
            NextState = nextState;
        }

        protected void ActivateNextState()
        {
            Context.Invoke(NextState);
        }
    }
}
