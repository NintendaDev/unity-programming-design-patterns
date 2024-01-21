using System;

namespace Example03.GameRules
{
    public interface ICondition
    {
        public event Action Completed;
    }
}