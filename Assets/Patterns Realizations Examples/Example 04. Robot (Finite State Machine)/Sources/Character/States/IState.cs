namespace Example04.Character.States
{
    public interface IState
    {
        public void Enter();

        public void Exit();

        public void Update();
    }
}
