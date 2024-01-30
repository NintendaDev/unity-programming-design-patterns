namespace Example04.Characters.StateMachine.States
{
    public class BaseState : IState
    {
        public BaseState(IStateSwitcher stateSwitcher, Robot robot)
        {
            _stateSwitcher = stateSwitcher;
            View = robot.View;
        }

        private IStateSwitcher _stateSwitcher;

        protected RobotView View { get; private set; }

        public virtual void Enter()
        {
            View.StartMoving();
        }

        public virtual void Exit()
        {
            View.StopMoving();
        }

        public virtual void Update()
        {
        }

        protected void SwitchState<T>() where T : IState
        {
            _stateSwitcher.SwitchState<T>();
        }
    }
}
