namespace Example05.Characters.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Exit();
        void HandleInput();
        void Update();
    }
}
