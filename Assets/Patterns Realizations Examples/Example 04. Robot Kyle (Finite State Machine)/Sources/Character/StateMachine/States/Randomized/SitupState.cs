namespace Example04.Characters.StateMachine.States.Randomized
{
    public class SitupState : RandomizeState
    {
        public SitupState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        {
        }

        public override void Enter()
        {
            base.Enter();
            View.StartSitup();
        }

        public override void Exit()
        {
            base.Exit();
            View.StopSitup();
        }

        protected override bool IsPlayingStateAnimation()
        {
            return View.IsPlayingSitupAnimation();
        }
    }
}
