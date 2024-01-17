using System;

namespace Example03.GameRules
{
    public interface IWinRule 
    {
        public event Action Won;

        public event Action Lost;

        public abstract void Process();
    }
}
