using PirateIsland.Core;
using PirateIsland.Player;
using PirateIsland.Player.States;
using PirateIsland.States;
using UnityEngine;
using Zenject;

namespace PirateIsland.ZenjectInstallers
{
    public class PlayerStatesMachineInstaller : MonoInstaller
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private WalkingPlayerState.Settings _walkingPlayerStateSettings;

        [Inject] private IMovementPointerPositionProvider _pointerProvider;
        [Inject] private IMovementInputsProvider _movementInputsProvider;
        [Inject] private ICoroutineExecutor _coroutineExecutor;

        public override void InstallBindings()
        {
            State idlePlayerState = new IdlePlayerState(_playerAnimator);
            State walkingPlayerState = new WalkingPlayerState(
                _playerAnimator, _coroutineExecutor, _pointerProvider, _walkingPlayerStateSettings);

            MovementInputsTriggeredTransition idleStateTransition 
                = new MovementInputsTriggeredTransition(
                    walkingPlayerState, WalkingInputActions.StartMovement, _movementInputsProvider);

            MovementInputsTriggeredTransition walkingPlayerStateTransition
               = new MovementInputsTriggeredTransition(
                   idlePlayerState, WalkingInputActions.StopMovement, _movementInputsProvider);

            idlePlayerState.AddTransition(idleStateTransition);
            walkingPlayerState.AddTransition(walkingPlayerStateTransition);

            Container.Bind<IStatesMachine>().To<StatesMachine>()
                .FromInstance(new StatesMachine(idlePlayerState)).AsSingle();
        }
    }
}
