using System;
using System.Collections;
using PirateIsland.Core;
using UnityEngine;

namespace PirateIsland.Player.States
{
    public class WalkingPlayerState : PlayerState
    {
        private ICoroutineExecutor _coroutineExecutor;
        private IMovementPointerPositionProvider _positionProvider;
        private Settings _settings;
        private Coroutine _coroutine;

        public WalkingPlayerState(
            Animator playerAnimator,
            ICoroutineExecutor coroutineExecutor,
            IMovementPointerPositionProvider positionProvider,
            Settings settings)
            : base(playerAnimator)
        {
            _coroutineExecutor = coroutineExecutor;
            _positionProvider = positionProvider;
            _settings = settings;
        }

        protected override void Start()
        {
            PlayerAnimator.SetBool("move", true);
            _coroutine = _coroutineExecutor.ExecuteCoroutine(StartWalkingProcess());
        }

        protected override void Stop()
        {
            if(_coroutine != null )
                _coroutineExecutor.BreakCoroutine(_coroutine);
        }

        private IEnumerator StartWalkingProcess()
        {
            while (true)
            {
                Vector2 moveDirection = CalculateMoveDirection();
                Vector2 playerPosition = _settings.PlayerRigidbody2D.position;

                _settings.PlayerRigidbody2D.MovePosition(
                    playerPosition + moveDirection * _settings.WalkingSpeed * Time.deltaTime);

                _settings.PlayerRotatablePart.up = moveDirection;
                yield return new WaitForFixedUpdate();
            }
        }

        private Vector2 CalculateMoveDirection()
        {
            Vector2 pointerPosition = _positionProvider.GetPointerPosition();
            pointerPosition -= new Vector2(Screen.width, Screen.height) / 2f;
            return pointerPosition.normalized;
        }

        [Serializable]
        public class Settings
        {
            [SerializeField] private float _walkingSpeed = 3f;
            [SerializeField] private Rigidbody2D _playerRigidbody2D;
            [SerializeField] private Transform _playerRotatablePart;

            public float WalkingSpeed { get => _walkingSpeed; }
            public Rigidbody2D PlayerRigidbody2D { get => _playerRigidbody2D; }
            public Transform PlayerRotatablePart { get => _playerRotatablePart; }
        }
    }
}
