using System.Collections.Generic;

namespace PirateIsland.States
{
    public abstract class State : EnterableObject<StateSwitchHandler>, IState
    {
        private List<ITransition> _transitions = new List<ITransition>();

        protected override void OnEnter()
        {
            foreach (var transition in _transitions)
                transition.Enter(Context);

            Start();
        }

        protected override void OnExit()
        {
            foreach (var transition in _transitions)
                transition.Exit();

            Stop();
        }

        protected abstract void Stop();
       
        protected abstract void Start();

        public void AddTransition(ITransition transition)
            => _transitions.Add(transition);

        public void ClearTransitions()
            => _transitions.Clear();

        public void AddTransitions(ICollection<ITransition> transitions)
        {
            foreach (var transition in transitions)
                _transitions.Add(transition);
        }
    }
}
