using Example02.Dialogue;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example02.NPC
{
    public class Seller : MonoBehaviour
    {
        [SerializeField, Required]private string _name = "Very harmful seller";
        [SerializeField, Required] private PlayerDetector _playerDetector;

        private IPlayerGreeting _playerGreetingUpponDetection;
        private readonly string _defaultGreeting = "Come over to me, I have excellent merchandise!";

        public event Action<string> PlayerGreeted;

        public string Name => _name;

        public string DefaultGreeting => _defaultGreeting;

        public void SetPlayerGreeting(IPlayerGreeting playerGreetingUpponDetection)
        {
            _playerGreetingUpponDetection = playerGreetingUpponDetection;
        }

        private void OnEnable()
        {
            _playerDetector.Detected += OnPlayerDetect;
            _playerDetector.Lost += OnPlayerLost;
        }

        private void OnDisable()
        {
            _playerDetector.Detected -= OnPlayerDetect;
            _playerDetector.Lost -= OnPlayerLost;
        }

        private void OnPlayerDetect()
        {
            PlayerGreeted?.Invoke(_playerGreetingUpponDetection.GetPlayerGreeting());
        }

        private void OnPlayerLost()
        {
            PlayerGreeted?.Invoke(_defaultGreeting);
        }
    }
}
