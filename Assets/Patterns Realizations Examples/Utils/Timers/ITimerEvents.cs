using System;

namespace Utils.Timers
{
    public interface ITimerEvents
    {
        public event Action Started;

        public event Action Stopped;
    }
}
