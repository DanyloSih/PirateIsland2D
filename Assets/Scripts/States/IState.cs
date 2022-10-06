using System.Collections.Generic;

namespace PirateIsland.States
{
    public delegate void StateSwitchHandler(IState nextState);

    public interface IState : IEnterableObject<StateSwitchHandler>
    {
        void AddTransition(ITransition transition);

        void AddTransitions(ICollection<ITransition> transitions);

        void ClearTransitions();
    }
}