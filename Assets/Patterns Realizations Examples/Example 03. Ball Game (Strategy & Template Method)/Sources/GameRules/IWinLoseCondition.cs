using Example03.Core;
using System;

namespace Example03.GameRules
{
    public interface IWinLoseCondition : IRestart
    {
        public event Action Won;

        public event Action Lost;
    }
}