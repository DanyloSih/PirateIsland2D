using PirateIsland.States;
using UnityEngine;
using Zenject;

namespace PirateIsland.Player.States
{
    public class MovementInputsTriggeredTransition : Transition, IMovementInputsReceiver
    {
        private WalkingInputActions _triggeringAction;
        private IMovementInputsProvider _movementInputsProvider;

        public MovementInputsTriggeredTransition(
            IState nextState,
            WalkingInputActions triggeringAction,
            IMovementInputsProvider movementInputsProvider) 
            : base(nextState)
        {
            _triggeringAction = triggeringAction;
            _movementInputsProvider = movementInputsProvider;
        }

        protected override void OnEnter()
        {
            _movementInputsProvider.AddListner(this);
        }

        protected override void OnExit()
        {
            _movementInputsProvider.RemoveListner(this);
        }

        public void OnMovementStart()
        {
            if (_triggeringAction == WalkingInputActions.StartMovement)
                ActivateNextState();
        }

        public void OnMovementStop()
        {
            if (_triggeringAction == WalkingInputActions.StopMovement)
                ActivateNextState();
        }

        public void OnMovePointerUpdated(Vector2 newPoistion)
        {
            if (_triggeringAction == WalkingInputActions.PointerMoved)
                ActivateNextState();
        }
    }
}
