using System;
using UnityEngine;

namespace Utils.Timers
{
    public abstract class Timer : ITimerEvents
    {
        private float _initialTime;
        private float _time;

        protected Timer()
        {
            State = TimerState.Stopped;
        }

        public event Action Started;

        public event Action Stopped;

        public event Action Finished;

        public TimerState State { get; private set; }

        public float Progress => Time / _initialTime;

        public bool IsFinished => Time == 0;

        protected float Time { 

            get => _time; 

            private set
            {
                _time = Mathf.Max(value, 0);
            }
        }

        public abstract void Start();

        public void Stop()
        {
            if (State == TimerState.Running)
            {
                Reset();
                Stopped?.Invoke();
            }
        }

        public void Resume()
        {
            if (State != TimerState.Paused)
                throw new Exception("Timer is not paused");

            State = TimerState.Running;
        }

        public void Pause()
        {
            if (State != TimerState.Running)
                throw new Exception("Timer is not running");

            State = TimerState.Paused;
        }

        public void Reset()
        {
            State = TimerState.Stopped;
        }

        public void Tick()
        {
            if (State != TimerState.Running)
                return;
            
            Time -= UnityEngine.Time.deltaTime;

            if (Time == 0)
            {
                Stop();
                Finished?.Invoke();
            }
        }

        protected void Start(float startValue)
        {
            if (State != TimerState.Stopped)
                throw new Exception("The timer is already running. Stop or reset before starting.");

            _initialTime = startValue;
            Time = startValue;

            State = TimerState.Running;
            Started?.Invoke();
        }
    }
}