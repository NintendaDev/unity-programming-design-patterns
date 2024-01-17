using Example03.Accounters;
using System;

namespace Example03.GameRules
{
    public abstract class BallAccounterWinRuler
    {
        private BurstBallsAccounter _burtsBallAccounter;
        private bool _isEndGame;

        public BallAccounterWinRuler(BurstBallsAccounter burtsBallAccounter)
        {
            _burtsBallAccounter = burtsBallAccounter;
        }

        public event Action Won;

        public event Action Lost;

        public bool IsEndGame => _isEndGame;

        protected BurstBallsAccounter BurstBallsAccounter => _burtsBallAccounter;


        public abstract void Process();

        protected void SendWinEvent()
        {
            if (_isEndGame)
                return;

            Won?.Invoke();
            _isEndGame = true;
        }

        protected void SendLoseEvent()
        {
            if (_isEndGame)
                return;

            Lost?.Invoke();
            _isEndGame = true;
        }
    }
}
