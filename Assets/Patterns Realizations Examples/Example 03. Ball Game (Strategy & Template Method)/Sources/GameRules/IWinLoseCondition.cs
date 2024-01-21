using System;

namespace Example03.GameRules
{
    public interface IWinLoseCondition
    {
        public event Action Won;

        public event Action Lost;
    }
}