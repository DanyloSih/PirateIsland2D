using PirateIsland.States;
using UnityEngine;

namespace PirateIsland.Player.States
{
    public abstract class PlayerState : State
    {
        private Animator _playerAnimator;

        public PlayerState(Animator playerAnimator) 
        {
            _playerAnimator = playerAnimator;
        }

        protected Animator PlayerAnimator { get => _playerAnimator; }

        protected override void Stop()
        {

        }
    }
}
