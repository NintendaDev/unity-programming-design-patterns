using Example04.Characters.StateMachine.States;

namespace Example04.Characters.StateMachine
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : IState;

        public void SwitchRandomState();
    }
}
