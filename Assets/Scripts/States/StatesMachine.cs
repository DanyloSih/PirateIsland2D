using System;

namespace PirateIsland.States
{
    public class StatesMachine : IStatesMachine
    {
        private IState _currentState;

        public StatesMachine(IState initialState)
        {
            SwitchState(initialState);
        }

        public void SwitchState(IState state)
        {
            if (state == null)
                throw new ArgumentNullException();

            if(_currentState != null)
                _currentState.Exit();

            _currentState = state;
            _currentState.Enter(SwitchState);
        }
    }
}
