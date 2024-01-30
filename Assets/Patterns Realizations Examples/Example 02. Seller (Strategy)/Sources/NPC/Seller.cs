using Example02.Dialogue;
using MonoUtils;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example02.NPC
{
    public class Seller : InitializedMonobehaviour
    {
        [SerializeField, Required] private string _name = "Harmful seller";
        [SerializeField, Required] private TradableDetector _tradableDetector;

        private ITradableGreeting _greetingForDetection;
        private readonly string _defaultGreeting = "Come over to me, I have excellent merchandise!";

        public event Action<string> TradableGreeted;

        public string Name => _name;

        public string DefaultGreeting => _defaultGreeting;

        public void Initialize()
        {
            _tradableDetector.Initialize();

            CompleteInitialization();
        }

        public void SetGreeting(ITradableGreeting greetingForDetection)
        {
            _greetingForDetection = greetingForDetection;
        }

        private void OnEnable()
        {
            _tradableDetector.Detected += OnTradableDetect;
            _tradableDetector.Lost += OnTradableLost;
        }

        private void OnDisable()
        {
            _tradableDetector.Detected -= OnTradableDetect;
            _tradableDetector.Lost -= OnTradableLost;
        }

        private void OnTradableDetect(ITradable tradableSubject)
        {
            TradableGreeted?.Invoke(_greetingForDetection.GetPlayerGreeting());
        }

        private void OnTradableLost(ITradable tradableSubject)
        {
            TradableGreeted?.Invoke(_defaultGreeting);
        }
    }
}
