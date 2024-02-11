using System;
using System.Collections.Generic;

namespace Example03.GameRules
{
    public class WinLoseCondition : IWinLoseCondition
    {
        private List<ICondition> _loseConditions;
        private List<ICondition> _winConditions;

        public WinLoseCondition(IEnumerable<ICondition> winConditions, IEnumerable<ICondition> loseConditions) : this(winConditions)
        {
            _loseConditions = new List<ICondition>(loseConditions);
            Subscribe(_loseConditions, OnLoseConditionCompleted);
        }

        public WinLoseCondition(IEnumerable<ICondition> winConditions)
        {
            _winConditions = new List<ICondition>(winConditions);
            Subscribe(_winConditions, OnWinConditionCompleted);
        }

        public event Action Won;

        public event Action Lost;

        public virtual void Restart()
        {
            Unsubscribe();

            foreach (ICondition condition in _winConditions)
                condition.Restart();

            Subscribe(_winConditions, OnWinConditionCompleted);

            if (_loseConditions != null)
            {
                foreach (ICondition condition in _loseConditions)
                    condition.Restart();

                Subscribe(_loseConditions, OnLoseConditionCompleted);
            }
        }

        private void OnWinConditionCompleted()
        {
            Unsubscribe();
            Won?.Invoke();
        }

        private void OnLoseConditionCompleted()
        {
            Unsubscribe();
            Lost?.Invoke();
        }

        private void Subscribe(List<ICondition> conditions, Action subscribeMethod)
        {
            foreach (ICondition condition in conditions)
                condition.Completed += subscribeMethod;
        }

        private void Unsubscribe()
        {
            Unsubscribe(_winConditions, OnWinConditionCompleted);

            if (_loseConditions != null)
                Unsubscribe(_loseConditions, OnLoseConditionCompleted);
        }

        private void Unsubscribe(List<ICondition> conditions, Action subscribeMethod)
        {
            foreach (ICondition condition in conditions)
                condition.Completed -= subscribeMethod;
        }
    }
}
