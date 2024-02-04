using Example09.Accounters;
using System;

namespace Example09.UI
{
    public class ScoreViewMediator : IDisposable
    {
        private ScoreView _scoreView;
        private Score _score;

        public ScoreViewMediator(Score score, ScoreView scoreView)
        {
            _scoreView = scoreView;
            _score = score;

            UpdateScoreView(_score.Value);

            _score.Changed += OnScoreChanged;
        }

        public void Dispose()
        {
            _score.Changed -= OnScoreChanged;
        }

        private void UpdateScoreView(int currentValue)
        {
            _scoreView.UpdateView(currentValue);
        }

        private void OnScoreChanged(int previousValue, int currentValue)
        {
            UpdateScoreView(currentValue);
        }
    }
}
