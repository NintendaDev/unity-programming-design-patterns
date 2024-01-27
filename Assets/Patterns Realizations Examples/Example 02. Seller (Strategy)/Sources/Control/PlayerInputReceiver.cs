using MonoUtils;
using UnityEngine;

namespace Example02.Control
{
    [RequireComponent(typeof(Mover))]
    public class PlayerInputReceiver : InitializedMonobehaviour
    {
        private PlayerInputEventer _playerInputEventer;
        private Mover _mover;

        public void Initialize()
        {
            _playerInputEventer = new PlayerInputEventer();
            _mover = GetComponent<Mover>();
            IsInitialized = true;
        }

        private void OnEnable()
        {
            _playerInputEventer.Enable();
            _playerInputEventer.MovePressed += OnMove;
        }

        private void OnDisable()
        {
            _playerInputEventer.Disable();
            _playerInputEventer.MovePressed -= OnMove;
        }

        private void OnMove(Vector3 destination)
        {
            _mover.Move(destination);
        }
    }
}
