using Example03.Core;
using System;

namespace Example03.GameRules
{
    public interface ICondition : IRestart
    {
        public event Action Completed;
    }
}