using Utils.Timers;

namespace Example04.Characters.StateMachine.States.Action
{
    public abstract class ActionState : BaseState
    {
        private Timer _timer;
        private bool _timerStarted;

        public ActionState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        {
            _timer = new RandomCountdownTimer(robot.MinMaxRandomStateTime.x, robot.MinMaxRandomStateTime.y);
        }

        public override void Enter()
        {
            base.Enter();

            Reset();
            View.StartAction();
            _timer.Finished += OnStateTimerFinish;
        }

        public override void Exit()
        {
            base.Exit();

            View.StopAction();
        }

        public override void Update()
        {
            base.Update();

            _timer.Tick();

            if (_timerStarted == false && IsPlayingStateAnimation())
            {
                _timer.Start();
                _timerStarted = true;
            }
        }

        protected abstract bool IsPlayingStateAnimation();

        private void Reset()
        {
            _timer.Reset();
            _timerStarted = false;
        }

        private void OnStateTimerFinish()
        {
            _timer.Finished -= OnStateTimerFinish;
            SwitchState<WalkState>();
        }
    }
}
