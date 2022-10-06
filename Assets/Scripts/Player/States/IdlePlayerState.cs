using UnityEngine;

namespace PirateIsland.Player.States
{
    public class IdlePlayerState : PlayerState
    {
        public IdlePlayerState(Animator playerAnimator) 
            : base(playerAnimator)
        {
        }

        protected override void Start()
        {
            if(PlayerAnimator.isInitialized)
                PlayerAnimator.SetBool("move", false);
        }
    }
}
