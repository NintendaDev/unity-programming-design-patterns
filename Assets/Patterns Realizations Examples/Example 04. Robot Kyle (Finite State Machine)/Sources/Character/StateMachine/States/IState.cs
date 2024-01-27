namespace Example04.Characters.StateMachine.States
{
    public interface IState
    {
        public void Enter();

        public void Exit();

        public void Update();
    }
}
