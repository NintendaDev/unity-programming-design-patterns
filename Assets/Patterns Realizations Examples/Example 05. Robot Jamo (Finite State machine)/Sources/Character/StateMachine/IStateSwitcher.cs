using Example05.Characters.StateMachine.States;

namespace Example05.Characters.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}