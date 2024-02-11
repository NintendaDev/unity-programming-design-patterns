using Example03.GameRules;
using System;

namespace Example03.Handlers
{
    public class Level
    {
        private IWinLoseCondition _winLoseCondition;
        private bool _isSubscribed;

        public event Action Won;

        public event Action Lost;

        public void SetWinRuller(IWinLoseCondition winLoseCondition)
        {
            if (_winLoseCondition != null)  
                Unsubscribe();

            _winLoseCondition = winLoseCondition;
            Subscribe();
        }

        private void Subscribe()
        {
            if (_isSubscribed || _winLoseCondition == null)
                return;

            _winLoseCondition.Won += OnWin;
            _winLoseCondition.Lost += OnLose;
            
            _isSubscribed = true;
        }

        private void OnWin()
        {
            Won?.Invoke();
        }

        private void OnLose()
        {
            Lost?.Invoke();
        }

        private void Unsubscribe()
        {
            if (_winLoseCondition == null)
                return;

            _winLoseCondition.Won -= OnWin;
            _winLoseCondition.Lost -= OnLose;

            _isSubscribed = false;
        }
    }
}
