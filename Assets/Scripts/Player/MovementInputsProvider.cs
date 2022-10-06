using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PirateIsland.Player
{
    public class MovementInputsProvider : MonoBehaviour, IMovementInputsProvider, IMovementPointerPositionProvider
    {
        private MainControls _mainControls;
        private Coroutine _sendSignalCoroutine;
        private List<IMovementInputsReceiver> _movementInputsReceivers = new List<IMovementInputsReceiver>();

        public void AddListner(IMovementInputsReceiver movementInputsReceiver)
            => _movementInputsReceivers.Add(movementInputsReceiver);

        public void RemoveListner(IMovementInputsReceiver movementInputsReceiver)
            => _movementInputsReceivers.Remove(movementInputsReceiver);

        public Vector2 GetPointerPosition()
        {
            return _mainControls == null
                ? Vector2.zero
                : _mainControls.Movement.Pointer.ReadValue<Vector2>();
        }

        protected void Awake()
        {
            _mainControls = new MainControls();
            _mainControls.Movement.StartMovement.performed += OnStartMovementPerformed;
            _mainControls.Movement.StopMovement.performed += OnStopMovementPerformed;
        }

        protected void OnEnable()
        {
            _mainControls.Enable();
        }

        protected void OnDisable()
        {
            _mainControls.Disable();
        }

        private IEnumerator SendMoveSignal()
        {
            while (true)
            {
                Vector2 pointerPosition = _mainControls.Movement.Pointer.ReadValue<Vector2>();
                for (int i = _movementInputsReceivers.Count - 1; i >= 0; i--)
                    _movementInputsReceivers[i].OnMovePointerUpdated(pointerPosition);

                yield return new WaitForEndOfFrame();
            }
        }

        private void OnStartMovementPerformed(InputAction.CallbackContext obj)
        {
            if (_sendSignalCoroutine != null)
                StopCoroutine(_sendSignalCoroutine);

            for (int i = _movementInputsReceivers.Count - 1; i >= 0; i--)
                _movementInputsReceivers[i].OnMovementStart();

            _sendSignalCoroutine = StartCoroutine(SendMoveSignal());
        }

        private void OnStopMovementPerformed(InputAction.CallbackContext obj)
        {
            StopCoroutine(_sendSignalCoroutine);

            for (int i = _movementInputsReceivers.Count - 1; i >= 0; i--)
                _movementInputsReceivers[i].OnMovementStop();
        }
    }
}
