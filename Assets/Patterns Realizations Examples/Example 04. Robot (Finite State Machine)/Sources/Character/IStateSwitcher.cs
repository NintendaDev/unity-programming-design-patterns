using Example04.Character.States;

namespace Example04.Character
{
    public interface IStateSwitcher
    {
        public void SwitchState<T>() where T : IState;
    }
}
