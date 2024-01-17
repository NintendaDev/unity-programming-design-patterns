using Example03.Accounters;
using Example03.GameRules;
using Example03.Items;
using System;
using UnityEngine;

namespace Example03.Handler
{
    public class Level : MonoBehaviour
    {
        private IWinRule _winRuller;
        private bool _isSubscribed;
        private BurstBallsAccounter _burstBallsAccounter;

        public event Action Won;

        public event Action Lost;

        public void Initialize(BurstBallsAccounter burstBallsAccounter)
        {
            _burstBallsAccounter = burstBallsAccounter;
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void SetWinRuller(IWinRule winRuller)
        {
            if (_winRuller != null)  
                Unsubscribe();

            _winRuller = winRuller;
            Subscribe();
        }

        private void Subscribe()
        {
            if (_isSubscribed || _winRuller == null)
                return;

            _burstBallsAccounter.BallBursted += OnBallBurst;
            _winRuller.Won += OnWin;
            _winRuller.Lost += OnLose;
            
            _isSubscribed = true;
        }

        private void OnBallBurst(BallColor ballColor)
        {
            _winRuller.Process();
        }

        private void OnWin()
        {
            Won?.Invoke();
            Debug.Log("Ты победил!");
        }

        private void OnLose()
        {
            Lost?.Invoke();
            Debug.Log("Ты проиграл!");
        }

        private void Unsubscribe()
        {
            if (_winRuller == null)
                return;

            _burstBallsAccounter.BallBursted -= OnBallBurst;
            _winRuller.Won -= OnWin;
            _winRuller.Lost -= OnLose;

            _isSubscribed = false;
        }
    }
}
