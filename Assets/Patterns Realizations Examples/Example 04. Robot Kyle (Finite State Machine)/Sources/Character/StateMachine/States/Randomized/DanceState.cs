namespace Example04.Characters.StateMachine.States.Randomized
{
    public class DanceState : RandomizeState
    {
        public DanceState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        {
        }

        public override void Enter()
        {
            base.Enter();
            View.StartDance();
        }

        public override void Exit()
        {
            base.Exit();
            View.StopDance();
        }

        protected override bool IsPlayingStateAnimation()
        {
            return View.IsPlayingDanceAnimation();
        }
    }
}
